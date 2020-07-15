using System.Collections.Generic;

namespace Match3Logic.LogicAction
{
    public class BaseLogicAction
    {
        public virtual ActionType ActionType { get; }
        
        private readonly List<Element> _elements;
        
        public List<Element> Elements
        {
            get { return _elements; }
        }
        
        public BaseLogicAction(List<Element> elements)
        {
            _elements = elements;
        }
    }
}