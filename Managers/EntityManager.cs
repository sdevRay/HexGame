using HexGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace HexGame.Managers
{
    static class EntityManager
    {
        private static List<Entity> _entities = new List<Entity>();
        private static List<Entity> _addedEntities = new List<Entity>();
        private static List<Hex> _hexes = new List<Hex>();

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

        public static void Update()
        {
            _isUpdating = true;

            HandleCollisions();

            foreach(var entity in _entities)
            {
                entity.Update();
            }

            _isUpdating = false;

            foreach (var entity in _addedEntities)
            {
                AddEntity(entity);
            }

            _addedEntities.Clear();
        }

        private static void HandleCollisions()
        {
            foreach(var hex in _hexes)
            {
                if (IsPointHover(hex))
                {
                    hex.HandleCollisions();
                }
            }
        }

        public static void DrawTest(SpriteBatch spriteBatch, Texture2D texture)
        {
            foreach(var hex in _hexes)
            {
                hex.DrawBoundingBox(spriteBatch, texture, Color.Chocolate);
            }
        }

        private static bool IsPointHover(Hex entity)
        {
            return entity.Bounds.Contains(Input.MousePosition);
        }

        private static bool IsColliding(Hex entity)
        {
            //float radius = entity.Radius + Input.Radius;
            //return Vector2.DistanceSquared(entity.Position, Input.MousePosition) < radius * radius;

            return false;
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
