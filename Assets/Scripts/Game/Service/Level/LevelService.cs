using Core;
using Core.Binder;
using Game.Service.Level.Model;

namespace Game.Service.Level
{
    public class LevelService : ILevelService
    {
        private IResourceCache _resourceCache;
        private LevelMapper _levelMapper;
        
        public void Initialize()
        {
            _resourceCache = BindManager.GetInstance<IResourceCache>();
            _levelMapper = new LevelMapper();
        }
        
        public LevelModel GetLevel(int levelIndex)
        {
            var levelConfig = _resourceCache.GameConfig.GetLevelConfig(levelIndex);
            return _levelMapper.MapData(levelConfig);
        }
    }
}