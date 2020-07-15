using Game.UI.Base;

namespace Game.Service.UI
{
    public interface IUIService : IService
    {
        void ShowScreen<T>() where T : BaseMediator;
    }
}