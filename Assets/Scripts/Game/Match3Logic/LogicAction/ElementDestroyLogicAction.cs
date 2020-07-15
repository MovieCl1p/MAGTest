using System.Collections.Generic;

namespace Match3Logic.LogicAction
{
    public class ElementDestroyLogicAction : BaseLogicAction
    {
        public override ActionType ActionType
        {
            get { return ActionType.Destroy; }
        }

        public ElementDestroyLogicAction(List<Element> elements) : base(elements)
        {
        }
    }
}