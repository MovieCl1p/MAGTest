using System;
using System.Collections.Generic;
using System.Linq;
using Game.Service.Level.Model;
using Game.UI.Game.View;
using Match3Logic.LogicAction;

namespace Match3Logic
{
    public class MatchLogic : IMatchLogic
    {
        public event Action<BaseLogicAction> OnLogicStep;

        private Field _field;
        private FieldGenerator _generator;
        private List<Element> _elements;
        private MatchHandler _matchHandler;
        
        public void Initialize()
        {
            _generator = new FieldGenerator();
            _matchHandler = new MatchHandler();
        }

        public void StartLevel(LevelModel levelModel)
        {
            _field = new Field(levelModel);
            _elements = _generator.Generate(_field);
            while (!CheckFieldCombination())
            {
                _elements = _generator.Generate(_field);
            }
            
            CallSpawnAction(_elements);
        }

        private bool CheckFieldCombination()
        {
            return _matchHandler.FindMatch(_elements.ToList<IElementTypeAndPosition>());
        }

        public void ProcessGesture(List<IElementTypeAndPosition> items)
        {
            var matchItems = CheckMatches(items);
            if (matchItems == null || matchItems.Count == 0)
            {
                return;
            }
            
            var destroyedElements = DestroyElements(matchItems);
            var movedElements = MoveField(matchItems);
            var newElements = SpawnNewElements(matchItems, movedElements);
            
            CallDestroyAction(destroyedElements);
            CallMoveAction(movedElements);
            CallSpawnAction(newElements);
        }

        public bool CheckEnd()
        {
            return !CheckFieldCombination();
        }

        private List<Element> SpawnNewElements(List<IElementTypeAndPosition> matchItems, List<Element> movedElements)
        {
            List<IPosition> spawnPositions = new List<IPosition>();

            var freeTiles = _field.GetFreeTiles();
            for (int i = 0; i < freeTiles.Count; i++)
            {
                spawnPositions.Add(new SamplePosition(freeTiles[i].X, freeTiles[i].Y));
                _field.Tiles[freeTiles[i].X, freeTiles[i].Y].Occupied = true;
            }
            
            var result = _generator.Respawn(spawnPositions);
            _elements.AddRange(result);
            return result;
        }

        private List<Element> MoveField(List<IElementTypeAndPosition> removedItems)
        {
            List<Element> result = new List<Element>();
            
            for (int i = 0; i < removedItems.Count; i++)
            {
                var index = i;
                var items = _elements.Where(x => x.X == removedItems[index].X && x.Y < removedItems[index].Y).ToList();
                items.Sort(Comparison);

                for (int j = 0; j < items.Count; j++)
                {
                    var item = items[j];
                    _field.Tiles[item.X, item.Y].Occupied = false;
                    
                    int dif = removedItems[i].Y - item.Y;
                    item.SetY(item.Y + dif - j);
                    
                    _field.Tiles[item.X, item.Y].Occupied = true;
                    
                    if (!result.Contains(items[j]))
                    {
                        result.Add(items[j]);
                    }
                }
            }

            return result;
        }

        private int Comparison(IElementTypeAndPosition x, IElementTypeAndPosition y)
        {
            if (x.Y < y.Y)
                return 1;
            return x.Y > y.Y ? -1 : 0;
        }

        private List<IElementTypeAndPosition> CheckMatches(List<IElementTypeAndPosition> viewItems)
        {
            return _matchHandler.ProcessMatch(viewItems);
        }

        private List<Element> DestroyElements(List<IElementTypeAndPosition> items)
        {
            List<Element> result = new List<Element>();
            for (int i = 0; i < items.Count; i++)
            {
                var view = items[i];
                var item = _elements.FirstOrDefault(x => x.X == view.X && x.Y == view.Y);
                if (item != null)
                {
                    result.Add(item);
                    _elements.Remove(item);
                    _field.Tiles[item.X, item.Y].Occupied = false;
                }
            }

            return result;    
        }
        
        private void CallSpawnAction(List<Element> elements)
        {
            OnLogicStep?.Invoke(new ElementSpawnLogicAction(elements));
        }
        
        private void CallDestroyAction(List<Element> elements)
        {
            OnLogicStep?.Invoke(new ElementDestroyLogicAction(elements));
        }
        
        private void CallMoveAction(List<Element> elements)
        {
            OnLogicStep?.Invoke(new ElementMoveLogicAction(elements));
        }
    }
}