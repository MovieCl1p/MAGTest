using System.IO;
using Game.Service.Data;
using UnityEngine;

namespace Game.Service
{
    public class UserService : IUserService
    {
        private const string _dataPath = "UserData.json";
        
        private UserData _userData;
        
        public void Initialize()
        {
            LoadData();
        }
        
        public UserData GetUserData()
        {
            return _userData;
        }

        public void AddScore(int score)
        {
            _userData.Score += score;
        }
        
        public void SetLevel(int level)
        {
            _userData.Level = level;
        }

        public void SaveData()
        {
            ParsedUserData parsedData  = new ParsedUserData(_userData);
            string json = JsonUtility.ToJson(parsedData, true);
            var path = Path.Combine(Application.persistentDataPath, _dataPath);
            File.WriteAllText(path, json);
        }

        public void LoadData()
        {
            var path = Path.Combine(Application.persistentDataPath, _dataPath);
            if (!File.Exists(path))
            {
                _userData = UserData.Default;
                return;
            }
            
            string json = File.ReadAllText(path);
            ParsedUserData parsedData = JsonUtility.FromJson<ParsedUserData>(json);
            _userData = new UserData(parsedData);
        }

        
    }
}