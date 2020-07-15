using System;
using System.Collections.Generic;
using Core.Binder;
using Factories.Field;


namespace Match3Logic
{
    public class FieldGenerator
    {
        private readonly IFieldFactory _fieldFactory;
        
        public List<Element> Generate(Field field)
        {
            List<Element> result = new List<Element>();
            Random rnd = new Random();

            foreach (Tile tile in field.Tiles)
            {
                if (!tile.Available)
                {
                    continue;
                }

                ElementType elementType = (ElementType) rnd.Next(0, (int) ElementType.Count);
                Element element = new Element(tile.X, tile.Y, elementType, Guid.NewGuid().ToString());
                result.Add(element);
                tile.Occupied = true;
            }

            return result;
        }
        
        public List<Element> Respawn(List<IPosition> tiles)
        {
            List<Element> result = new List<Element>();
            Random rnd = new Random();
            for (int i = 0; i < tiles.Count; i++)
            {
                var tile = tiles[i];

                ElementType elementType = (ElementType) rnd.Next(0, (int) ElementType.Count);
                Element element = new Element(tile.X, tile.Y, elementType, Guid.NewGuid().ToString());
                result.Add(element);
            }

            return result;
        }
    }
}