using Core;
using Core.Binder;

namespace Game.Factories.Unit
{
    public class UnitFactory : IUnitFactory
    {
        private IResourceCache _resourceCache;

        public void Init()
        {
            if (_resourceCache == null)
            {
                _resourceCache = BindManager.GetInstance<IResourceCache>();
            }
        }
        
//        public IUnitView GetUnit(Transform parent)
//        {
//            return _resourceCache.CreateAsset<UnitView>(_resourceCache.PrefabConfig.UnitView, parent);
//        }
//
//        public RocketView GetRocket(Transform parent)
//        {
//            return _resourceCache.CreateAsset<RocketView>(_resourceCache.PrefabConfig.RocketView, parent);
//        }

    }
}