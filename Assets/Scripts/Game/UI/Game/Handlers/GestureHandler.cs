using System;
using System.Collections.Generic;
using Game.UI.Game.View;
using UnityEngine;

namespace UI.Game.Handlers
{
    public class GestureHandler
    {
        public Action<List<ElementView>> OnGesture;
        
        private bool _checking = false;
        private List<ElementView> _elementsToCheck = new List<ElementView>();
        
        public void OnElementUp(ElementView element)
        {
            OnGesture?.Invoke(_elementsToCheck);
            
            _checking = false;
            _elementsToCheck.Clear();
        }

        public void OnElementEnter(ElementView element)
        {
            if (!_checking)
            {
                return;
            }

            if (!_elementsToCheck.Contains(element))
            {
                _elementsToCheck.Add(element);
            }
        }

        public void OnElementDown(ElementView element)
        {
            _checking = true;
            _elementsToCheck.Add(element);
        }
    }
}