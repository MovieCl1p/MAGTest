using Factories;
using Game.Service;
using Game.UI.Game.View;
using Match3Logic;

namespace Factories.Field
{
    public interface IFieldFactory : IFactory, IService
    {
        TileView GetTile(Tile tile);
        ElementView GetElement();
    }
}