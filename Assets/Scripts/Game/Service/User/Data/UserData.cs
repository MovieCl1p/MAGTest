using Core.UI;

namespace Game.Service.Data
{
    public class UserData
    {
        public int Level { get; set; }
        
        public int Score { get; set; }
        
        public UserData(int level, int score)
        {
            Level = level;
            Score = score;
        }

        public UserData(ParsedUserData parsedData)
        {
            Level = parsedData.Level;
            Score = parsedData.Score;
        }

        public static UserData Default
        {
            get
            {
                return new UserData(1, 0);
            }
        }
    }
}