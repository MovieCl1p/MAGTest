using Core.UI;
using Match3Logic;
using UnityEngine;

namespace Game.UI.Game.View
{
    public class ElementDataContext : IDataContext, IElementTypeAndPosition
    {
        public ElementType ElementType { get; }
        public int X { get; }
        public int Y { get; }
        public Vector3 FieldPosition { get; set; }
        public Vector3 TargetPosition { get; set; }
        public string Id { get; }

        public ElementDataContext(Element data)
        {
            Id = data.Id;
            X = data.X;
            Y = data.Y;
            ElementType = data.ElementType;
        }

        public void Dispose()
        {
        }
    }
}