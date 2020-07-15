namespace Match3Logic
{
    public class Element : IElementTypeAndPosition
    {
        public ElementType ElementType { get; } 
        public int X { get; private set; }
        public int Y { get; set; }
        public string Id { get; set; }

//        public int NextX { get; set; }
//        public int NextY { get; set; }
        
        public Element(int dX, int dY, ElementType type, string id)
        {
            X = dX;
            Y = dY;
            ElementType = type;
            Id = id;
        }

        public void SetY(int y)
        {
            Y = y;
        }
    }
}