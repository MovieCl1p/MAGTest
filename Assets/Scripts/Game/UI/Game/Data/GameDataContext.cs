using Core.UI;
using Game.Service.Level.Model;

namespace Game.UI.Data
{
    public class GameDataContext : IDataContext
    {
        public FieldDataContext LevelDataContext { get; }
        public int Score { get; set; }
        
        public GameDataContext(LevelModel levelModel, int score)
        {
            Score = score;
            LevelDataContext = new FieldDataContext(levelModel);
        }

        public void Dispose()
        {
        }
    }
}