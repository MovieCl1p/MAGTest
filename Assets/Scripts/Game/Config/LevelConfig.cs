using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Config
{
    [Serializable]
    public class TileConfigModel
    {
        public TileType TileType;
        public int X;
        public int Y;

        public TileConfigModel(int x, int y, TileType tileType)
        {
            X = x;
            Y = y;
            TileType = tileType;
        }
    }
    
    
    [Serializable]
    public class TileList
    {
        public List<TileType> Tiles;

        public TileList()
        {
            Tiles = new List<TileType>();
        }
    }
    
    public class LevelConfig : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TileConfigModel> _configs;
        
        public int rows = 5;
        public int columns = 5;
        
        [SerializeField]
        private List<TileList> _tiles;
        
        public int LevelIndex;
        
        public List<TileList> Tiles
        {
            get { return _tiles; }
        }

        public List<TileConfigModel> Configs
        {
            get { return _configs; }
        }

        

        public void OnBeforeSerialize()
        {
            const int count = 5;

            SetCapacity(ref _tiles, count);

            for(int i = 0; i < count; i++)
            {
                SetCapacity(ref Tiles[i].Tiles, count);
            }

            if (Configs == null || Configs.Count == 0)
            {
                _configs = new List<TileConfigModel>(25);
                rows = 5;
                columns = 5;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Configs.Add(new TileConfigModel(i, j, TileType.Open));
                    }
                }
            }
        }

        public void OnAfterDeserialize()
        {
        }
        
        private static void SetCapacity<T>(ref List<T> list, int count) where T : new()
        {
            if(list == null)
            {
                list = new List<T>(count);
            }

            while(list.Count < count)
            {
                list.Add(new T());
            }

            while(list.Count > count)
            {
                list.RemoveAt(count - 1);
            }

            list.Capacity = count;
        }
    }
    
    public enum TileType
    {
        Close = 0,
        Open = 1,
        Empty = 2,
        
        Count = 3
    }
}