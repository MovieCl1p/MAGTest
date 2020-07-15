using Core.UI.Components;
using Match3Logic;
using UnityEngine;

namespace Game.UI.Game.View
{
    public class TileView : BaseComponent<TileDataContext>
    {
        protected override void OnContextUpdate(TileDataContext context)
        {
            base.OnContextUpdate(context);
            
            transform.GetComponent<RectTransform>().localPosition = context.FieldPosition;
        }
    }
}