using HexGame.Entities;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace HexGame
{
    static class EntityManager
    {
        private static List<Entity> _entities = new List<Entity>();
        private static List<Entity> _addedEntities = new List<Entity>();
        public static List<Hex> _hexes = new List<Hex>();

        private static bool _isUpdating;
        public static void Add(Entity entity)
        {
            if (!_isUpdating)
            {
                AddEntity(entity);
            }
            else
            {
                _addedEntities.Add(entity);
            }
        }

        private static void AddEntity(Entity entity)
        {
            _entities.Add(entity);

            if (entity is Hex)
            {
                _hexes.Add(entity as Hex);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach(var entity in _entities)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}
