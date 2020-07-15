using System;
using System.Collections.Generic;
using Core.UI;
using Game.Service.Data;
using Game.Service.Level.Model;
using Game.UI.Data;
using Match3Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Game.View
{
    public class GameScreen : BaseView, IViewElementsContainer, IScoreContainer
    {
        public Action<List<ElementView>> OnGestureFinished;
        
        public event Action OnRestartClick;
        public event Action OnMainMenuClick;
        
        [SerializeField] 
        private Text _scoreLabel;
        
        [SerializeField] 
        private FinishScreen _finishScreen;
        
        [SerializeField] 
        private FieldView _fieldView;

        private GameDataContext _context;
        
        protected override void Start()
        {
            base.Start();
            
            _finishScreen.OnMainMenuClick += OnMainMenu;
            _finishScreen.OnRestartClick += OnRestart;
            
            _fieldView.OnGestureFinished += OnGesture;
        }

        private void OnGesture(List<ElementView> items)
        {
            OnGestureFinished?.Invoke(items);
        }

        public void SetDataContext(GameDataContext context)
        {
            _context = context;
            OnScoreChange(_context.Score);
            _fieldView.SetContext(context.LevelDataContext);
        }

        public void ShowFinishScreen()
        {
            _finishScreen.Show(_context.Score);
        }
        
        private void OnMainMenu()
        {
            _finishScreen.Hide();
            OnMainMenuClick?.Invoke();
        }
        
        private void OnRestart()
        {
            _finishScreen.Hide();
            OnRestartClick?.Invoke();
        }

        protected override void OnReleaseResources()
        {
            _fieldView.OnGestureFinished -= OnGesture;
            
            _finishScreen.OnMainMenuClick -= OnMainMenu;
            _finishScreen.OnRestartClick -= OnRestart;
            
            base.OnReleaseResources();
        }

        public void SpawnElement(Element data)
        {
            _fieldView.SpawnElement(data);
        }
        
        public void DestroyElement(Element element)
        {
            _fieldView.DestroyElement(element);
        }

        public void MoveElement(Element element)
        {
            _fieldView.MoveElement(element);
        }

        public void AddScore(int scorePerTurn)
        {
            _context.Score += scorePerTurn;
            OnScoreChange(_context.Score);
        }
        
        private void OnScoreChange(int data)
        {
            _scoreLabel.text = $"Score: { data }";
        }

        
    }
}