using Core.UI;
using Match3Logic;
using UnityEngine;

namespace Game.UI.Game.View
{
    public class TileDataContext : IDataContext, IPosition
    {
        public int X { get; }
        public int Y { get; }
        public Vector3 FieldPosition { get; set; }
        
        public TileDataContext(Tile tile)
        {
            X = tile.X;
            Y = tile.Y;
        }

        public void Dispose()
        {
        }
    }
}