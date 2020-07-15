using System;
using System.Collections.Generic;
using Game.Service;
using Game.Service.Level.Model;
using Game.UI.Game.View;
using Match3Logic.LogicAction;

namespace Match3Logic
{
    public interface IMatchLogic : IService
    {
        event Action<BaseLogicAction> OnLogicStep;
        
        void StartLevel(LevelModel levelModel);
        void ProcessGesture(List<IElementTypeAndPosition> items);
        bool CheckEnd();
    }
}