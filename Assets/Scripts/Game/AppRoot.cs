using Core;
using Core.Binder;
using DefaultNamespace.Commands;
using Game.Service.UI;
using Game.UI.MainMenu.Mediator;

namespace Game
{
    public class AppRoot : SingletonBaseMonoBehaviour<AppRoot>
    {
        protected override void Start()
        {
            base.Start();
            
            StartCommand startCommand = new StartCommand(OnReadyToPlay);
            startCommand.Execute();
        }

        private void OnReadyToPlay()
        {
            BindManager.GetInstance<IUIService>().ShowScreen<MainMenuMediator>();
        }
    }
}