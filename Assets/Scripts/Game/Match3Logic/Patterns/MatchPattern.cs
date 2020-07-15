using System.Collections.Generic;
using Game.UI.Game.View;

namespace Match3Logic.Patterns
{
    public abstract class MatchPattern
    {
        public abstract bool Process(List<IElementTypeAndPosition> result, List<IElementTypeAndPosition> viewItems);

        public abstract bool FindMatch(List<IElementTypeAndPosition> elements);
    }
}