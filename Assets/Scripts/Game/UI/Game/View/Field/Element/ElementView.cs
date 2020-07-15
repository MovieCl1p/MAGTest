using System;
using System.Collections;
using Core;
using Core.Binder;
using Core.Dispatcher;
using Core.UI.Components;
using UI.Game;
using UI.Game.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Game.View
{
    public class ElementView : BaseComponent<ElementDataContext>
    {
        public Action<ElementView> OnDown;
        public Action<ElementView> OnEnter;
        public Action<ElementView> OnUp;
        
        [SerializeField] 
        private Image _image;
        
        [SerializeField] 
        private ElementInput _button;

        [Inject]
        public IResourceCache ResourceCache { get; set; }
        
        [Inject]
        public IDispatcher Dispatcher { get; set; }

        private float _moveTime = 0.5f;
        
        protected override void Start()
        {
            base.Start();
            _button.OnDown += OnInputDown;
            _button.OnUp += OnInputUp;
            _button.OnEnter += OnInputEnter;
        }

        private void OnInputEnter()
        {
            OnEnter?.Invoke(this);
        }

        private void OnInputUp()
        {
            OnUp?.Invoke(this);
        }

        private void OnInputDown()
        {
            OnDown?.Invoke(this);
        }

        protected override void OnContextUpdate(ElementDataContext context)
        {
            base.OnContextUpdate(context);

            CachedRectTransform.localPosition = context.FieldPosition;
            _image.sprite = ResourceCache.PrefabConfig.GetElementSprite(context.ElementType);

            _button.name = context.ElementType.ToString();

            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            float dT = 0;

            while (dT < _moveTime)
            {
                CachedRectTransform.localPosition = Vector3.Lerp(DataContext.FieldPosition, DataContext.TargetPosition, dT / _moveTime);
                dT += Time.deltaTime;
                yield return null;
            }
            
            Dispatcher.Fire(new ElementFinishMoveSignal(DataContext.Id));
        }

        protected override void OnReleaseResources()
        {
            _button.OnDown -= OnInputDown;
            _button.OnUp -= OnInputUp;
            _button.OnEnter -= OnInputEnter;
            base.OnReleaseResources();
        }
    }
}