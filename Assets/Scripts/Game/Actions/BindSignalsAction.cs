using Core.Actions;
using Core.Binder;
using Core.Dispatcher;
using UI.Game.Signals;

namespace Game.Actions
{
    public class BindSignalsAction : BaseAction
    {
        public override void Execute()
        {
            base.Execute();
            var dispatcher = BindManager.GetInstance<IDispatcher>();
            dispatcher.DeclareSignal<ElementFinishMoveSignal>();
            
            Complete();
        }
    }
}