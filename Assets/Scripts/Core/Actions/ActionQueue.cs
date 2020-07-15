using System;
using System.Collections.Generic;

namespace Core.Actions
{
    public class ActionQueue
    {
        private readonly List<IAction> _actions;

        private Action<string> _onQueueFail;
        private Action _onQueueSuccess;
        
        private int _currentIndex;
        private bool _isPaused;
        private bool _isDestroyed;

        public ActionQueue()
        {
            _actions = new List<IAction>();
        }

        public void AddAction(IAction actionObject)
        {
            _actions.Add(actionObject);
        }

        public void AddActionAt(IAction actionObject, int index)
        {
            _actions.Insert(index, actionObject);
        }

        public void Start()
        {
            _currentIndex = 0;
            ExecuteAction();
        }

        public void Start(Action onSuccess, Action<string> onFail)
        {
            _onQueueFail = onFail;
            _onQueueSuccess = onSuccess;
            Start();
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            if (_isPaused)
            {
                _isPaused = false;
                ExecuteAction();
            }
        }

        private void ExecuteAction()
        {
            if (_isPaused)
            {
                return;
            }

            if (_currentIndex < _actions.Count)
            {
                var delegateObject = _actions[_currentIndex];
                delegateObject.OnComplete += OnActionExecuteComplete;
                delegateObject.OnFail += OnActionExecuteFail;
                delegateObject.Execute();
            }
            else
            {
                OnQueueFinished();
                Destroy();
            }
        }

        private void OnActionExecuteComplete()
        {
            var action = _actions[_currentIndex];
            action.OnComplete -= OnActionExecuteComplete;
            action.OnFail -= OnActionExecuteFail;

            _currentIndex++;
            ExecuteAction();
        }

        private void OnActionExecuteFail(string error)
        {
            _onQueueFail.Invoke(error);
            Destroy();
        }

        private void OnQueueFinished()
        {
            _onQueueSuccess?.Invoke();
        }

        private void Destroy()
        {
            if (_isDestroyed)
            {
                return;
            }

            foreach (var action in _actions)
            {
                action.OnComplete -= OnActionExecuteComplete;
                action.OnFail -= OnActionExecuteFail;
                action.Destroy();
            }

            _actions.Clear();
            _onQueueFail = null;
            _onQueueSuccess = null;
            _isDestroyed = true;
        }
    }
}