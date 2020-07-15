using System.Collections.Generic;
using Game.UI.Game.View;

namespace Match3Logic.Patterns
{
    public class LinePattern : MatchPattern
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

            if (second.Y == first.Y && third.Y == first.Y)
            {
                if (second.X == first.X + 1 && third.X == first.X + 2)
                {
                    result.AddRange(new List<IElementTypeAndPosition> { first, second, third });
                    return true;
                }
                
                if (second.X == first.X - 1 && third.X == first.X - 2)
                {
                    result.AddRange(new List<IElementTypeAndPosition> { first, second, third });
                    return true;
                }
            }
            
            if (second.X == first.X && third.X == first.X)
            {
                if (second.Y == first.Y + 1 && third.Y == first.Y + 2)
                {
                    result.AddRange(new List<IElementTypeAndPosition> { first, second, third });
                    return true;
                }
                
                if (second.Y == first.Y - 1 && third.Y == first.Y - 2)
                {
                    result.AddRange(new List<IElementTypeAndPosition> { first, second, third });
                    return true;
                }
            }
            
            return false;
        }

        public override bool FindMatch(List<IElementTypeAndPosition> elements)
        {
            if (elements.Count < 3)
            {
                return false;
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if (i + 2 >= elements.Count)
                {
                    break;
                }
                
                int index = i;
                IElementTypeAndPosition first = elements[index];
                IElementTypeAndPosition second = elements[++index];
                IElementTypeAndPosition third = elements[++index];
                
                if (second.ElementType != first.ElementType || third.ElementType != first.ElementType)
                {
                    continue;
                }
                
                if (second.Y == first.Y && third.Y == first.Y)
                {
                    if (second.X == first.X + 1 && third.X == first.X + 2)
                    {
                        return true;
                    }
                
                    if (second.X == first.X - 1 && third.X == first.X - 2)
                    {
                        return true;
                    }
                }
            
                if (second.X == first.X && third.X == first.X)
                {
                    if (second.Y == first.Y + 1 && third.Y == first.Y + 2)
                    {
                        return true;
                    }
                
                    if (second.Y == first.Y - 1 && third.Y == first.Y - 2)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}