using System;
using Core;
using Core.Binder;
using Core.UI;
using Game.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.MainMenu.View
{
    public class MainMenuScreen : BaseView
    {
        public Action OnStartButtonClick;
        public Action OnSaveClick;
        public Action OnLoadClick;
        public Action<int> OnLevelSelect;
        
        [SerializeField] 
        private Button _startButton;

        [SerializeField] 
        private Text _scoreLabel;
        
        [SerializeField] 
        private Transform _content;
        
        [SerializeField] 
        private LevelItemView _prefab;
        
        [SerializeField] 
        private Button _saveButton;
        
        [SerializeField] 
        private Button _loadButton;
        
        [Inject]
        public IUserService UserService { get; set; }
        
        [Inject]
        public IResourceCache ResourceCache { get; set; }
        
        protected override void Start()
        {
            base.Start();
            
            _startButton.onClick.AddListener(OnStartClick);
            _saveButton.onClick.AddListener(SaveClick);
            _loadButton.onClick.AddListener(LoadClick);
        }

        private void LoadClick()
        {
            OnLoadClick?.Invoke();
        }

        private void SaveClick()
        {
            OnSaveClick?.Invoke();
        }

        public void UpdateData()
        {
            var userData = UserService.GetUserData();
            _scoreLabel.text = $"Score: {userData.Score}";
            
            UpdateScroll();
        }

        private void UpdateScroll()
        {
            for (int i = 0; i < ResourceCache.GameConfig.Levels.Count; i++)
            {
                var config = ResourceCache.GameConfig.Levels[i];
                LevelItemView item = Instantiate(_prefab, _content);
                
                item.SetContext(new LevelItemData(config.LevelIndex));
                item.OnClick += SelectLevel;
            }
        }

        private void SelectLevel(LevelItemData level)
        {
            OnLevelSelect?.Invoke(level.LevelIndex);
        }
        
        private void OnStartClick()
        {
            OnStartButtonClick?.Invoke();
        }

        protected override void OnReleaseResources()
        {
//            for (int i = 0; i < _items.Count; i++)
//            {
//                _items[i].OnClick -= SelectPlanet;
//            }
//            _items.Clear();
            
            _startButton.onClick.RemoveListener(OnStartClick);
            _saveButton.onClick.RemoveListener(SaveClick);
            _loadButton.onClick.RemoveListener(LoadClick);
            base.OnReleaseResources();
        }
    }
}