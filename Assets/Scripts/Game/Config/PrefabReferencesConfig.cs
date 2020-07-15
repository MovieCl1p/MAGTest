using System.Collections.Generic;
using System.Linq;
using Game.UI.Game.View;
using Match3Logic;
using UnityEngine;

namespace Game.Config
{
    public class PrefabReferencesConfig : ScriptableObject
    {
        public List<TileAsset> Tiles;
        public List<ElementAsset> Elements;
        public List<ElementSpriteAsset> ElementSprites;
        public PrefabAsset LevelItemView;
        
        public TileAsset GetTile(TileType tileType)
        {
            return Tiles.FirstOrDefault(x => x.TileType == tileType);
        }

        public ElementAsset GetElement()
        {
            return Elements.FirstOrDefault();
        }
        
        public Sprite GetElementSprite(ElementType elementType)
        {
            return ElementSprites.FirstOrDefault(x => x.ElementType == elementType)?.Sprite;
        }
    }
}