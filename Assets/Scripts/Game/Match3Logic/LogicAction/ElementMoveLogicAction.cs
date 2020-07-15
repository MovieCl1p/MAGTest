using System.Collections.Generic;

namespace Match3Logic.LogicAction
{
    public class ElementMoveLogicAction : BaseLogicAction
    {
        public override ActionType ActionType
        {
            get { return ActionType.Move; }
        }

        public ElementMoveLogicAction(List<Element> elements) : base(elements)
        {
        }
    }
}