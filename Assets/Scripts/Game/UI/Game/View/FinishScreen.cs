using System;
using Core.UI;
using Game.Service.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Game.View
{
    public class FinishScreen : BaseView
    {
        public event Action OnRestartClick;
        public event Action OnMainMenuClick;

        [SerializeField] 
        private Text _score;
        
        [SerializeField] 
        private Button _restartButton;
        
        [SerializeField] 
        private Button _mainMenuButton;

        protected override void Start()
        {
            base.Start();
            
            _restartButton.onClick.AddListener(RestartClick);
            _mainMenuButton.onClick.AddListener(MainMenuClick);
        }

        private void MainMenuClick()
        {
            OnMainMenuClick?.Invoke();
        }

        private void RestartClick()
        {
            OnRestartClick?.Invoke();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show(int score)
        {
            _score.text = $"Score: {score}";
            gameObject.SetActive(true);
        }

        protected override void OnReleaseResources()
        {
            _restartButton.onClick.RemoveListener(RestartClick);
            _mainMenuButton.onClick.RemoveListener(MainMenuClick);
            base.OnReleaseResources();
        }
    }
}