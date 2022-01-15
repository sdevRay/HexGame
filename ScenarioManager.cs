using HexGame.Entities;
using HexGame.Types;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace HexGame
{
    static class ScenarioManager
    {
        private static float _hexScale = 0.5f;

        public static void LoadMap()
        {

            var screenCoordDict = GetScreenCoordinatesDict(8, 12);
            // https://gavindraper.com/2010/11/25/how-to-loadsave-game-state-in-xna/
            // https://community.monogame.net/t/solved-need-a-save-game-example/9136/4

        }

        private static IDictionary<Vector2, Vector2> GetScreenCoordinatesDict(int rows, int columns)
        {

            var dict = new Dictionary<Vector2, Vector2>();

            var srcRect = GetSourceRectangle(TerrainType.Hexagon);
            var scaleHeight = (int)(srcRect.Height * _hexScale);
            var scaleWidth = (int)(srcRect.Width * _hexScale);

            var offset = new Vector2(25, 25); // Offset from the upper-left corner
            var position = new Vector2(offset.X, offset.Y);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (y % 2 == 0 && x == 0)
                    {
                        position.X += (scaleWidth * 3) / 4;
                    }

                    //// if equal x and y assign stuff based on whats found in file
                    //var terrainType = TerrainType.Woods;

                    //if(x == 5)
                    //{
                    //    terrainType = TerrainType.Dirt;
                    //}

                    dict.Add(new Vector2(x, y), position);
                    //var hex = new Hex(new Vector2(position.X, position.Y), new Vector2(x, y), terrainType, _hexScale);

                    //EntityManager.Add(hex);

                    position.X += scaleWidth + (scaleWidth * 0.5f);
                }

                position.X = offset.X;
                position.Y += scaleHeight * 0.5f;
            }

            return dict;
        }

        private static readonly IDictionary<TerrainType, Rectangle> TerrainTypeTextureAtlasMapping = new Dictionary<TerrainType, Rectangle>()
        {
            { TerrainType.Hexagon, new Rectangle(0, 0, 222, 192) },
            { TerrainType.Woods, new Rectangle(222, 0, 222, 192) },
            { TerrainType.Road, new Rectangle(0, 192, 222, 192) },
            { TerrainType.Dirt, new Rectangle(222, 192, 222, 192) }
        };

        public static Rectangle GetSourceRectangle(TerrainType terrainType)
        {
            if (TerrainTypeTextureAtlasMapping.TryGetValue(terrainType, out Rectangle rectangle))
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
