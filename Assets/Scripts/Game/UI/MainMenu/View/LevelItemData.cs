using Core.UI;
using UnityEngine;

namespace Game.UI.MainMenu.View
{
    public class LevelItemData : IDataContext
    {
        public int LevelIndex { get; }

        public LevelItemData(int levelIndex)
        {
            LevelIndex = levelIndex;
        }

        public void Dispose()
        {
        }
    }
}