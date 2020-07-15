using Game.Service.Data;
using Game.Service.UI;

namespace Game.Service
{
    public interface IUserService : IService
    {
        UserData GetUserData();
        void AddScore(int score);
        void LoadData();
        void SaveData();
        void SetLevel(int level);
    }
}