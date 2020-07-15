using Game.UI.Game.View;
using Match3Logic.LogicAction;

namespace UI.Game.Handlers
{
    public class MoveActionHandler : ActionHandler<ElementMoveLogicAction>
    {
        private readonly IViewElementsContainer _container;

        public MoveActionHandler(IViewElementsContainer container)
        {
            _container = container;
        }

        protected override void OnExecute(ElementMoveLogicAction action)
        {
            base.OnExecute(action);

            for (int i = 0; i < action.Elements.Count; i++)
            {
                _container.MoveElement(action.Elements[i]);
            }
        }
    }
}