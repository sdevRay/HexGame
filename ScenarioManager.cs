using HexGame.Entities;
using HexGame.Types;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace HexGame
{
    static class ScenarioManager
    {
        private static float _hexScale = 0.1f;

        public static void SetupHexagons()
        {
            var cols = 8;
            var rows = 12;

            var scaleHeight = (int)(Art.HexagonTexture.Height * _hexScale);
            var scaleWidth = (int)(Art.HexagonTexture.Width * _hexScale);

            var offset = new Vector2(25, 25);
            var position = new Vector2(offset.X, offset.Y);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (y % 2 == 0 && x == 0)
                    {
                        position.X += (scaleWidth * 3) / 4;
                    }

                    var terrainType = TerrainType.Grass;
                    if(y == 3)
                    {
                        terrainType = TerrainType.Woods;
                    }

                    EntityManager.Add(new Hex(new Vector2(position.X, position.Y), new Vector2(x, y), terrainType, _hexScale));


                    position.X += scaleWidth + (scaleWidth * 0.5f);
                }

                position.X = offset.X;
                position.Y += scaleHeight * 0.5f;
            }
        }


        private static readonly IDictionary<TerrainType, Rectangle> TerrainTypeMapping = new Dictionary<TerrainType, Rectangle>()
        {
            { TerrainType.Grass, new Rectangle(0, 0, 443, 384) },
            { TerrainType.Woods, new Rectangle(443, 384, 443, 384) }
        };

        public static Rectangle GetSourceRectangle(TerrainType terrainType)
        {
            if (TerrainTypeMapping.TryGetValue(terrainType, out Rectangle rectangle))
            {
                return rectangle;
            }
            else
            {
                throw new ArgumentException($"{nameof(TerrainType)} not found: {terrainType}");
            }
        }
    }
}
