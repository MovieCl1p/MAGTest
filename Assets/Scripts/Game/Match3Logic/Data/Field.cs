using System.Collections.Generic;
using Game.Service.Level.Model;

namespace Match3Logic
{
    public class Field
    {
        private Tile[,] _tiles;

        public Tile[,] Tiles
        {
            get { return _tiles; }
        }
        
        public Field(LevelModel model)
        {
            _tiles = new Tile[model.LevelWidth, model.LevelHeight];
            for (int i = 0; i < model.Tiles.Count; i++)
            {
                var tile = model.Tiles[i];
                tile.Occupied = false;
                _tiles[tile.X, tile.Y] = tile;
            }
        }

        public List<Tile> GetFreeTiles()
        {
            List<Tile> result = new List<Tile>();
            foreach (Tile tile in _tiles)
            {
                if (!tile.Occupied && tile.Available)
                {
                    result.Add(tile);
                }
            }

            return result;
        }
    }
}