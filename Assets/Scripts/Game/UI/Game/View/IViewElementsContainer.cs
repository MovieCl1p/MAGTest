using Match3Logic;

namespace Game.UI.Game.View
{
    public interface IViewElementsContainer
    {
        void DestroyElement(Element element);
        void MoveElement(Element element);
        void SpawnElement(Element element);
    }
}