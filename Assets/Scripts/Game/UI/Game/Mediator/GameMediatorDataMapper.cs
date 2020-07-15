using Core.Binder;
using Game.Service.Data;
using Game.Service.Level;
using Game.Service.Level.Model;
using Game.UI.Data;

namespace Game.UI.Game.Mediator
{
    public class GameMediatorDataMapper
    {
        public GameDataContext MapData(LevelModel levelModel)
        {
            GameDataContext context = new GameDataContext(levelModel, 0);
            return context;
        }
    }
}