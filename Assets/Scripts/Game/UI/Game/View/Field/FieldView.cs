using System;
using System.Collections.Generic;
using System.Linq;
using Core.Binder;
using Core.UI.Components;
using Factories.Field;
using Game.UI.Data;
using Match3Logic;
using UI.Game.Handlers;
using UnityEngine;

namespace Game.UI.Game.View
{
    public class FieldView : BaseComponent<FieldDataContext>
    {
        public Action<List<ElementView>> OnGestureFinished;
        
        [SerializeField]
        private Vector2 _offset;
        
        [Inject]
        public IFieldFactory FieldFactory { get; set; }
        
        private List<ElementView> _elementViews = new List<ElementView>();
        
        private GestureHandler _gestureHandler = new GestureHandler();

        protected override void Start()
        {
            base.Start();
            _gestureHandler.OnGesture += OnGesture;
        }

        private void OnGesture(List<ElementView> items)
        {
            OnGestureFinished?.Invoke(items);
        }

        protected override void OnContextUpdate(FieldDataContext context)
        {
            base.OnContextUpdate(context);

            CleanField();
            UpdateField();
        }

        public void SpawnElement(Element data)
        {
            ElementView elementView = FieldFactory.GetElement();
            ElementDataContext context = new ElementDataContext(data);
            context.TargetPosition = GetTilePosition(context);
            context.FieldPosition = GetTilePosition(new SamplePosition(context.X, -1));
            
            elementView.transform.ChangeParent(transform);
            
            elementView.SetContext(context);
            
            _elementViews.Add(elementView);
            
            elementView.OnDown += OnElementDown;
            elementView.OnEnter += OnElementEnter;
            elementView.OnUp += OnElementUp;
        }

        public void MoveElement(Element element)
        {
            var view = _elementViews.FirstOrDefault(x => x.DataContext.Id == element.Id);
            if (view != null)
            {
                ElementDataContext context = new ElementDataContext(element);
                context.TargetPosition = GetTilePosition(new SamplePosition(element.X, element.Y));
                context.FieldPosition = GetTilePosition(new SamplePosition(view.DataContext.X, view.DataContext.Y));
                view.SetContext(context);
            }
        }
        
        private void OnElementUp(ElementView element)
        {
            _gestureHandler.OnElementUp(element);
        }

        private void OnElementEnter(ElementView element)
        {
            _gestureHandler.OnElementEnter(element);
        }

        private void OnElementDown(ElementView element)
        {
            _gestureHandler.OnElementDown(element);
        }

        private void UpdateField()
        {
            for (int i = 0; i < DataContext.Tiles.Count; i++)
            {
                TileView tile = FieldFactory.GetTile(DataContext.Tiles[i]);
                TileDataContext tileContext = new TileDataContext(DataContext.Tiles[i]);
                tileContext.FieldPosition = GetTilePosition(tileContext);
                
                tile.transform.ChangeParent(transform);
                
                tile.SetContext(tileContext);
            }
        }

        private Vector2 GetTilePosition(IPosition position)
        {
            float dx = position.X * DataContext.TileWidth;
            float dy = position.Y * -DataContext.TileHeight;
            
            return new Vector3(_offset.x + dx, _offset.y + dy, 0);
        }

        private void CleanField()
        {
            
        }

        protected override void OnReleaseResources()
        {
            _gestureHandler.OnGesture -= OnGesture;
            
            for (int i = 0; i < _elementViews.Count; i++)
            {
                _elementViews[i].OnDown -= OnElementDown;
                _elementViews[i].OnEnter -= OnElementEnter;
                _elementViews[i].OnUp -= OnElementUp;
            }
            base.OnReleaseResources();
        }

        public void DestroyElement(Element element)
        {
            var view = _elementViews.FirstOrDefault(x => x.DataContext.Id == element.Id);
            if (view != null)
            {
                view.OnDown -= OnElementDown;
                view.OnEnter -= OnElementEnter;
                view.OnUp -= OnElementUp;
                
                _elementViews.Remove(view);
                Destroy(view.gameObject);
            }
        }
    }
}