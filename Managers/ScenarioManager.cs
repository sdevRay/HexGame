using HexGame.Entities;
using HexGame.Models;
using HexGame.Types;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace HexGame.Managers
{
    static class ScenarioManager
    {
        private static float _hexScale = 0.5f;

        public static void LoadScenario(Scenario scenario)
        {
            if (scenario.Hexes == null)
            {
                throw new ArgumentNullException($"{nameof(LoadScenario)} failed to load {nameof(scenario.Hexes)} from {scenario.Title}.");
            }

            foreach (var hex in scenario.Hexes)
            {
                EntityManager.Add(hex);
            }
        }

        public static Scenario LoadFile(string fileName)
        {
            if(!File.Exists(fileName))
                return new Scenario();

            using (var reader = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(Scenario));
                var scenario = (Scenario)serializer.Deserialize(reader);

                return scenario;
            }
        }

        public static void SaveFile(Scenario scenario)
        {
            using (var writer = new StreamWriter(new FileStream("test1.scn", FileMode.Create)))
            {
                var serializer = new XmlSerializer(typeof(Scenario));
                serializer.Serialize(writer, scenario);
            }
        }

        public static List<Hex> CreateHexes(int columns, int rows)
        {
            var srcRect = GetSourceRectangle(TextureType.Hexagon);
            var scaleHeight = (int)(srcRect.Height * _hexScale);
            var scaleWidth = (int)(srcRect.Width * _hexScale);

            var offset = new Vector2(25, 25 + (scaleHeight * 0.5f)); // Offset from the upper-left corner
            var position = new Vector2(offset.X, offset.Y);
            var hexes = new List<Hex>();

            for(int x = 0; x < rows; x++)
            {
                for(int y = 0; y < columns; y++)
                {
					// build Hex here
					// need to assign texturetype here or somewhere else

                    var textureType = TextureType.Woods;

                    if (x == 1 && y == 1)
                    {
                        textureType = TextureType.Road;

                    }

                    if (x == 2 && y == 1)
                    {
                        textureType = TextureType.Dirt;

                    }


                    var hex = new Hex(new Vector2(position.X, position.Y), new Vector2(x, y), textureType, _hexScale);
                    hexes.Add(hex);

                    position.Y += scaleHeight;
                }

                if(x % 2 == 0)
                {
                    position.Y = offset.Y - (scaleHeight * 0.5f);
                }
                else
                {
                    position.Y = offset.Y;
                }

                position.X += scaleWidth * 0.75f;
            }

            return hexes;
        }

        private static readonly IDictionary<TextureType, Rectangle> TerrainTypeTextureAtlasMapping = new Dictionary<TextureType, Rectangle>()
        {
            { TextureType.Hexagon, new Rectangle(0, 0, 222, 192) },
            { TextureType.Woods, new Rectangle(222, 0, 222, 192) },
            { TextureType.Road, new Rectangle(0, 192, 222, 192) },
            { TextureType.Dirt, new Rectangle(222, 192, 222, 192) }
        };
        
        public static Rectangle GetSourceRectangle(TextureType terrainType)
        {
            if (TerrainTypeTextureAtlasMapping.TryGetValue(terrainType, out Rectangle rectangle))
            {
                return rectangle;
            }
            else
            {
                throw new ArgumentException($"{nameof(TextureType)} not found: {terrainType}");
            }
        }
    }
}
