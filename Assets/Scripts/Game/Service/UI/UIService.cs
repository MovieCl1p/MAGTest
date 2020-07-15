using System;
using System.Collections.Generic;
using Game.UI.Base;
using Game.UI.Game.Mediator;
using Game.UI.MainMenu.Mediator;
using UnityEngine;

namespace Game.Service.UI
{
    public class UIService : IUIService
    {
        private Dictionary<Type, BaseMediator> _mediators = new Dictionary<Type, BaseMediator>();
        private BaseMediator _activeMediator;
        
        public void Initialize()
        {
            _mediators.Add(typeof(MainMenuMediator), new MainMenuMediator());
            _mediators.Add(typeof(GameMediator), new GameMediator());
        }
        
        public void ShowScreen<T>() where T : BaseMediator
        {
            _activeMediator?.Exit();
            _activeMediator = GetMediator<T>();
            _activeMediator?.Entry();
        }
        
        private T GetMediator<T>() where T : BaseMediator
        {
            if (!_mediators.ContainsKey(typeof(T)))
            {
                return null;
            }

            return _mediators[typeof(T)] as T;
        }
    }
}