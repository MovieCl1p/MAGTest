using System.Collections.Generic;
using System.Linq;
using Core.Binder;
using Core.Dispatcher;
using Game.Service;
using Game.Service.Data;
using Game.Service.Level;
using Game.Service.Level.Model;
using Game.Service.UI;
using Game.UI.Base;
using Game.UI.Data;
using Game.UI.Game.View;
using Game.UI.MainMenu.Mediator;
using Match3Logic;
using Match3Logic.LogicAction;
using UI.Game;
using UI.Game.Signals;

namespace Game.UI.Game.Mediator
{
    public class GameMediator : BaseMediator<GameScreen>
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject] 
        public IUIService UIService { get; set; }
        
        [Inject] 
        public ILevelService LevelService { get; set; }
        
        [Inject] 
        public IMatchLogic IMatchLogic { get; set; }
        
        [Inject] 
        public IDispatcher Dispatcher { get; set; }

        private GameMediatorDataMapper _dataMapper = new GameMediatorDataMapper();
        
        private LogicActionHandler _actionHandler;
        private List<string> _cachedElements;

        protected override void OnEntry()
        {
            base.OnEntry();
            
            _actionHandler = new LogicActionHandler(View);
            
            View.OnGestureFinished += OnGestureFinished;
            View.OnMainMenuClick += OnMainMenuClick;
            View.OnRestartClick += OnRestartClick;
            
            InitializeField();
        }

        private void OnGestureFinished(List<ElementView> items)
        {
            IMatchLogic.ProcessGesture(items.Select(x => x.DataContext).ToList<IElementTypeAndPosition>());
        }

        private void InitializeField()
        {
            UserData userData = UserService.GetUserData();
            LevelModel levelModel = LevelService.GetLevel(userData.Level);
            GameDataContext context = _dataMapper.MapData(levelModel);
            context.Score = userData.Score;
            
            View.SetDataContext(context);
            
            IMatchLogic.OnLogicStep += OnLogicStep;
            IMatchLogic.StartLevel(levelModel);
        }

        private void OnLogicStep(BaseLogicAction logicAction)
        {
            ActionHandler handler = _actionHandler.GetHandler(logicAction);
            handler?.Execute(logicAction);

            if (logicAction.ActionType == ActionType.Move)
            {
                _cachedElements = logicAction.Elements.Select(x => x.Id).ToList();
                Dispatcher.Unsubscribe<ElementFinishMoveSignal>(OnFinishMove);
                Dispatcher.Subscribe<ElementFinishMoveSignal>(OnFinishMove);
            }
        }

        private void OnFinishMove(ElementFinishMoveSignal signal)
        {
            _cachedElements.Remove(signal.Id);
            if (_cachedElements.Count <= 0 && IMatchLogic.CheckEnd())
            {
                Dispatcher.Unsubscribe<ElementFinishMoveSignal>(OnFinishMove);
                View.ShowFinishScreen();
            }
        }
        
        private void OnMainMenuClick()
        {
            UIService.ShowScreen<MainMenuMediator>();
        }
        
        private void OnRestartClick()
        {
            Dispatcher.Unsubscribe<ElementFinishMoveSignal>(OnFinishMove);
            IMatchLogic.OnLogicStep -= OnLogicStep;
            InitializeField();
        }

        protected override void OnExit()
        {
            IMatchLogic.OnLogicStep -= OnLogicStep;
            
            View.OnGestureFinished -= OnGestureFinished;
            
            View.OnMainMenuClick -= OnMainMenuClick;
            View.OnRestartClick -= OnRestartClick;
            
            base.OnExit();
        }
    }
}