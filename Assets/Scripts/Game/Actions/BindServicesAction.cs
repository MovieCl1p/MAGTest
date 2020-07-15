using Core;
using Core.Actions;
using Core.Binder;
using Core.Dispatcher;
using Factories.Field;
using Game.Factories.Unit;
using Game.Service;
using Game.Service.Level;
using Game.Service.UI;
using Match3Logic;

namespace Game.Actions
{
    public class BindServicesAction : BaseAction
    {
        public override void Execute()
        {
            base.Execute();
            
            BindManager.Bind<IResourceCache>().To<ResourceCache>().ToSingleton();
            BindManager.Bind<IDispatcher>().To<Dispatcher>().ToSingleton();
            BindManager.Bind<IUserService>().To<UserService>().ToSingleton();
            
            BindManager.Bind<IUIService>().To<UIService>().ToSingleton();
            
            BindManager.Bind<IUnitFactory>().To<UnitFactory>().ToSingleton();
            BindManager.Bind<IFieldFactory>().To<FieldFactory>().ToSingleton();
            
            BindManager.Bind<IMatchLogic>().To<MatchLogic>().ToSingleton();
            BindManager.Bind<ILevelService>().To<LevelService>().ToSingleton();

            Complete();
        }
    }
}