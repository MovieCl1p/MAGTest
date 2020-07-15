using Game.Config;

namespace Match3Logic
{
    public class Tile
    {
        public TileType TileType { get; }
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        
        public bool Occupied { get; set; }
        
        public Tile(TileConfigModel config)
        {
            TileType = config.TileType;
            X = config.X;
            Y = config.Y;
            Width = 60;
            Height = 60;
        }

        public bool Available
        {
            get { return TileType == TileType.Open; }
        }
    }
}