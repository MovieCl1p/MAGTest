using Core.Dispatcher;

namespace UI.Game.Signals
{
    public class ElementFinishMoveSignal : ISignal
    {
        public string Id { get; }

        public ElementFinishMoveSignal(string id)
        {
            Id = id;
        }
    }
}