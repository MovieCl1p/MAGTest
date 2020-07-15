using System;
using Core.Actions;
using Game.Actions;
using UnityEngine;

namespace DefaultNamespace.Commands
{
    public class StartCommand
    {
        private readonly Action _callback;

        public StartCommand(Action callback)
        {
            _callback = callback;
        }
        
        public void Execute()
        {
            ActionQueue workFlow = new ActionQueue();
            workFlow.AddAction(new BindServicesAction());
            workFlow.AddAction(new InitializeServicesAction());
            workFlow.AddAction(new BindSignalsAction());
            workFlow.AddAction(new RegisterViewsAction());
            workFlow.Start(WorkFlowSuccess, WorkFlowFail);
        }

        private void WorkFlowFail(string error)
        {
            Debug.LogError("Work flow failed" + error);
        }

        private void WorkFlowSuccess()
        {
            _callback?.Invoke();
        }
    }
}