using System.Collections.Generic;
using Core.UI;
using Game.Service.Level.Model;
using Match3Logic;

namespace Game.UI.Data
{
    public class FieldDataContext : IDataContext
    {
        public int TileWidth { get; }
        
        public int TileHeight { get; }
        
        public List<Tile> Tiles { get; }

        public FieldDataContext(LevelModel levelModel)
        {
            TileWidth = 60;
            TileHeight = 60;

            Tiles = levelModel.Tiles;
        }

        public void Dispose()
        {
        }
    }
}