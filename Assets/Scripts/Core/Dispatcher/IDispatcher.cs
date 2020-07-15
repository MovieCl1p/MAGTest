using System;

namespace Core.Dispatcher
{
    public interface IDispatcher
    {
        void DeclareSignal<TSignal>(string identifier = null);

        void Subscribe<TSignal>(Action<TSignal> callback, string identifier = null) where TSignal : ISignal;

        void Unsubscribe<TSignal>(Action<TSignal> callback, string identifier = null);

        void Fire<TSignal>(TSignal signal, string identifier = null) where TSignal : ISignal;
    }
}