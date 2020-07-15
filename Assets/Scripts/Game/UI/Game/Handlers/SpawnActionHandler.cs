using Game.UI.Game.View;
using Match3Logic.LogicAction;

namespace UI.Game.Handlers
{
    public class SpawnActionHandler : ActionHandler<ElementSpawnLogicAction>
    {
        private readonly IViewElementsContainer _container;

        public SpawnActionHandler(IViewElementsContainer container)
        {
            _container = container;
        }

        protected override void OnExecute(ElementSpawnLogicAction action)
        {
            base.OnExecute(action);

            for (int i = 0; i < action.Elements.Count; i++)
            {
                _container.SpawnElement(action.Elements[i]);
            }
        }
    }
}