using Game.UI.Game.View;
using Match3Logic.LogicAction;

namespace UI.Game.Handlers
{
    public class DestroyActionHandler : ActionHandler<ElementDestroyLogicAction>
    {
        //It should be in configuration file
        private const int SCORE_PER_TURN = 10;
        
        private readonly IViewElementsContainer _container;
        private readonly IScoreContainer _score;

        public DestroyActionHandler(IViewElementsContainer container, IScoreContainer score)
        {
            _container = container;
            _score = score;
        }

        protected override void OnExecute(ElementDestroyLogicAction action)
        {
            base.OnExecute(action);

            for (int i = 0; i < action.Elements.Count; i++)
            {
                _container.DestroyElement(action.Elements[i]);
            }

            _score.AddScore(SCORE_PER_TURN);
        }
    }
}