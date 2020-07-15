using System.Collections.Generic;
using Game.UI.Game.View;

namespace Match3Logic.Patterns
{
    public class DiagonalPattern : MatchPattern
    {
        public override bool Process(List<IElementTypeAndPosition> result, List<IElementTypeAndPosition> viewItems)
        {
            if (viewItems.Count < 3)
            {
                return false;
            }

            int index = 0;
            IElementTypeAndPosition first = viewItems[index];
            IElementTypeAndPosition second = viewItems[++index];
            IElementTypeAndPosition third = viewItems[++index];
            
            if (second.ElementType != first.ElementType ||
                third.ElementType != first.ElementType)
            {
                return false;
            }

            //right up
            if((second.Y + 1 == first.Y && second.X - 1 == first.X) && (third.Y + 2 == first.Y && third.X - 2 == first.X))
            {
                result.AddRange(new List<IElementTypeAndPosition> { first, second, third });
                return true; 
            }
            
            //left up
            if((second.Y + 1 == first.Y && second.X + 1 == first.X) && (third.Y + 2 == first.Y && third.X + 2 == first.X))
            {
                result.AddRange(new List<IElementTypeAndPosition> { first, second, third });
                return true; 
            }
            
            //left bot
            if((second.Y - 1 == first.Y && second.X + 1 == first.X) && (third.Y - 2 == first.Y && third.X + 2 == first.X))
            {
                result.AddRange(new List<IElementTypeAndPosition> { first, second, third });
                return true; 
            }
            
            //right bot
            if((second.Y - 1 == first.Y && second.X - 1 == first.X) && (third.Y - 2 == first.Y && third.X - 2 == first.X))
            {
                result.AddRange(new List<IElementTypeAndPosition> { first, second, third });
                return true; 
            }
            
            return false;
        }

        public override bool FindMatch(List<IElementTypeAndPosition> elements)
        {
            return false;
        }
    }
}