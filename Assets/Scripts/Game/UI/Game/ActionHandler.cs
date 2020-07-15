using Match3Logic.LogicAction;

namespace UI.Game
{
    public class ActionHandler
    {
        public virtual void Execute(BaseLogicAction logicAction)
        {
        }
    }
    
    public class ActionHandler<T> : ActionHandler where T : BaseLogicAction
    {
        public override void Execute(BaseLogicAction logicAction)
        {
            base.Execute(logicAction);
            OnExecute(logicAction as T);
        }

        protected virtual void OnExecute(T data)
        {
        }
    }
}