using System;
using Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Game.View
{
    public class ElementInput : BaseMonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
    {
        public Action OnDown;
        public Action OnEnter;
        public Action OnUp;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUp?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnEnter?.Invoke();
        }
    }
}