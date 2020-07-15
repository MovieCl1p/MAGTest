using Game.Config;
using Game.Service.Level.Model;

namespace Game.Service.Level
{
    public class LevelMapper
    {
        public LevelModel MapData(LevelConfig levelConfig)
        {
            return new LevelModel(levelConfig);
        }
    }
}