using System.Collections.Generic;
using Game.UI.Game.View;
using Match3Logic.LogicAction;
using UI.Game.Handlers;

namespace UI.Game
{
    public class LogicActionHandler
    {
        private Dictionary<ActionType, ActionHandler> _handlers;
        
        public LogicActionHandler(GameScreen view)
        {
            _handlers = new Dictionary<ActionType, ActionHandler>();
            _handlers.Add(ActionType.Spawn, new SpawnActionHandler(view));
            _handlers.Add(ActionType.Destroy, new DestroyActionHandler(view, view));
            _handlers.Add(ActionType.Move, new MoveActionHandler(view));
        }
        
        public ActionHandler GetHandler(BaseLogicAction logicLogicAction)
        {
            if (_handlers.ContainsKey(logicLogicAction.ActionType))
            {
                return _handlers[logicLogicAction.ActionType];
            }

            return null;
        }
    }
}