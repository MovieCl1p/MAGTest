using Core;
using Core.Binder;
using Game.UI.Game.View;
using Match3Logic;
using UnityEngine;

namespace Factories.Field
{
    public class FieldFactory : IFieldFactory
    {
        private IResourceCache _resourceCache;

        public void Initialize()
        {
            _resourceCache =  BindManager.GetInstance<IResourceCache>();
        }
        
        public TileView GetTile(Tile tile)
        {
            GameObject go = GameObject.Instantiate(_resourceCache.PrefabConfig.GetTile(tile.TileType).Prefab);
            return go.GetComponent<TileView>();
        }

        public ElementView GetElement()
        {
            GameObject go = GameObject.Instantiate(_resourceCache.PrefabConfig.GetElement().Prefab);
            return go.GetComponent<ElementView>();
        }
    }
}