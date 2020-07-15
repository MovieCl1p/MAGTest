using System.Collections.Generic;

namespace Match3Logic.LogicAction
{
    public class ElementSpawnLogicAction : BaseLogicAction
    {
        public override ActionType ActionType
        {
            get { return ActionType.Spawn; }
        }

        public ElementSpawnLogicAction(List<Element> elements) : base(elements)
        {
        }
    }
}