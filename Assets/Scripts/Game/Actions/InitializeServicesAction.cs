using System;
using System.Linq;
using Core;
using Core.Actions;
using Core.Binder;
using Core.ViewManager;
using Factories.Field;
using Game.Service;
using Game.Service.Level;
using Game.Service.UI;
using Match3Logic;

namespace Game.Actions
{
    public class InitializeServicesAction : BaseAction
    {
        public override void Execute()
        {
            base.Execute();

            InitializeService<IResourceCache>();
            InitializeService<IUserService>();
            
            InitializeService<IUIService>();
            
            InitializeService<IMatchLogic>();
            InitializeService<ILevelService>();
            InitializeService<IFieldFactory>();
            
            ViewManager.Instance.Init();
            
            Complete();
        }

        private void InitializeService<T>() where T : IService
        {
            var service = BindManager.GetInstance<T>();
            service.Initialize();
        }
    }
}