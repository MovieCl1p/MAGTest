using System;
using Core.UI.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.MainMenu.View
{
    public class LevelItemView : BaseComponent<LevelItemData>
    {
        public event Action<LevelItemData> OnClick;
        
        [SerializeField] 
        private Text _text;
        
        [SerializeField] 
        private Button _button;

        protected override void Start()
        {
            base.Start();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            OnClick?.Invoke(DataContext);
        }

        protected override void OnContextUpdate(LevelItemData context)
        {
            base.OnContextUpdate(context);
            
            _text.text = $"Level: {context.LevelIndex}";
        }

        protected override void OnReleaseResources()
        {
            _button.onClick.RemoveListener(OnButtonClick);
            base.OnReleaseResources();
        }
    }
}