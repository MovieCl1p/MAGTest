using System.Collections.Generic;
using Game.UI.Game.View;
using Match3Logic.Patterns;

namespace Match3Logic
{
    public class MatchHandler
    {
        private List<MatchPattern> _patterns = new List<MatchPattern>();

        public MatchHandler()
        {
            _patterns.Add(new LinePattern());
            _patterns.Add(new DiagonalPattern());
        }
        
        public List<IElementTypeAndPosition> ProcessMatch(List<IElementTypeAndPosition> viewItems)
        {
            List<IElementTypeAndPosition> result = new List<IElementTypeAndPosition>();
            
            foreach (MatchPattern pattern in _patterns)
            {    
                if (pattern.Process(result, viewItems))
                {
                    return result;
                }
            }
            
            return null;
        }

        public bool FindMatch(List<IElementTypeAndPosition> elements)
        {
            foreach (MatchPattern pattern in _patterns)
            {    
                if (pattern.FindMatch(elements))
                {
                    return true;
                }
            }

            return false;
        }
    }
}