using System;

namespace Game.Service.Data
{
    [Serializable]
    public class ParsedUserData
    {
        public int Level { get; }
        public int Score { get; }

        public ParsedUserData()
        {
        }
        
        public ParsedUserData(UserData userData)
        {
            Level = userData.Level;
            Score = userData.Score;
        }
    }
}