using System;
using Match3Logic;

namespace UI.Game
{
    public static class ElementHelper
    {
        public static string GetImageName(ElementType elementType)
        {
            return string.Format("Element_" + (int) elementType);
        }
    }
}