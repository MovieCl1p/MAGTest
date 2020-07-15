using Core.Binder;
using Game.Service;
using Game.Service.UI;
using Game.UI.Base;
using Game.UI.Game.Mediator;
using Game.UI.MainMenu.View;

namespace Game.UI.MainMenu.Mediator
{
    public class MainMenuMediator : BaseMediator<MainMenuScreen>
    {
        [Inject]
        public IUIService UiService { get; set; }
        
        [Inject]
        public IUserService UserService { get; set; }
        
        protected override void OnEntry()
        {
            base.OnEntry();
            Subscribe();
            UpdateView();
        }

        private void UpdateView()
        {
            View.UpdateData();
        }

        private void OnStartClick()
        {
            UiService.ShowScreen<GameMediator>();
        }
        
        private void OnLoadClick()
        {
            UserService.LoadData();
            
        }

        private void OnSaveClick()
        {
            UserService.SaveData();
        }
        
        private void OnLevelSelected(int level)
        {
            UserService.SetLevel(level);
            OnStartClick();
        }
        
        protected override void OnExit()
        {
            base.OnExit();
            UnSubscribe();
        }
        
        private void Subscribe()
        {
            View.OnStartButtonClick += OnStartClick;
            View.OnSaveClick += OnSaveClick;
            View.OnLoadClick += OnLoadClick;
            
            View.OnLevelSelect += OnLevelSelected;
        }

        private void UnSubscribe()
        {
            View.OnStartButtonClick -= OnStartClick;
            View.OnLevelSelect -= OnLevelSelected;
            View.OnSaveClick -= OnSaveClick;
            View.OnLoadClick -= OnLoadClick;
        }
    }
}