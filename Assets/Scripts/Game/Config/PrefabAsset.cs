using System;
using Match3Logic;
using UnityEngine;

namespace Game.Config
{
    [Serializable]
    public class PrefabAsset
    {
        public GameObject Prefab;
    }
    
    [Serializable]
    public class ElementAsset
    {
        public GameObject Prefab;
    }
    
    [Serializable]
    public class TileAsset
    {
        public TileType TileType;
        public GameObject Prefab;
    }
    
    [Serializable]
    public class ElementSpriteAsset
    {
        public ElementType ElementType;
        public Sprite Sprite;
    }
}