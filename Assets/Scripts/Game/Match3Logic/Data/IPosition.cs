using System;

namespace Match3Logic
{
    public interface IPosition
    {
        int X { get; }
        int Y { get; }
    }
    
    public interface IElementType
    {
        ElementType ElementType { get; } 
    }
    
    public interface IElementTypeAndPosition : IElementType, IPosition
    {
    }

    public class SamplePosition : IPosition
    {
        public int X { get; }
        public int Y { get; }
        
        public SamplePosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class SampleType : IElementTypeAndPosition
    {
        public ElementType ElementType { get; }
        public int X { get; }
        public int Y { get; }
        
        public SampleType(int x, int y, ElementType elementType)
        {
            X = x;
            Y = y;
            ElementType = elementType;
        }
    }
}