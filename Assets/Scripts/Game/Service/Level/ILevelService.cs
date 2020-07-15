using Game.Service.Level.Model;

namespace Game.Service.Level
{
    public interface ILevelService : IService
    {
        LevelModel GetLevel(int levelIndex);
    }
}