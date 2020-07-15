using System.Collections.Generic;
using Game.Config;
using Match3Logic;

namespace Game.Service.Level.Model
{
    public class LevelModel
    {
        public int LevelWidth { get; }
        
        public int LevelHeight { get; }
        
        public List<Tile> Tiles { get; }
        
        public LevelModel(LevelConfig levelConfig)
        {
            LevelWidth = levelConfig.columns;
            LevelHeight = levelConfig.rows;
            
            Tiles = new List<Tile>(LevelWidth * LevelHeight);
            for (int i = 0; i < levelConfig.Configs.Count; i++)
            {
                var config = levelConfig.Configs[i];
                Tiles.Add(new Tile(config));
                
            }
        }
    }
}