using System;
using System.Collections.Generic;
using System.Linq;
using Game.Service.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Config
{
    public class GameConfig : ScriptableObject
    {
        public List<LevelConfig> Levels;

        public LevelConfig GetLevelConfig(int levelIndex)
        {
            return Levels.FirstOrDefault(x => x.LevelIndex == levelIndex);
        }
    }
}