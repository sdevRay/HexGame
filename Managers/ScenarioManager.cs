using HexGame.Entities;
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

        public static void NewScenario()
        {

        }

        public static void LoadScenario(string fileName)
        {
            var scn = LoadFile(fileName);

            for(int i = 0; i < scn.Hexes.Count; i++)
            {
                EntityManager.Add(scn.Hexes[i]);
            }
        }

        public static Scenario LoadFile(string fileName)
        {
            if(!File.Exists("test1.xml"))
                return new Scenario();

            using (var reader = new StreamReader(new FileStream("test1.xml", FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(Scenario));
                var scenario = (Scenario)serializer.Deserialize(reader);

                return scenario;
            }
        }

        public static void SaveFile(Scenario scenario)
        {
            using (var writer = new StreamWriter(new FileStream("test1.xml", FileMode.Create)))
            {
                var serializer = new XmlSerializer(typeof(Scenario));
                serializer.Serialize(writer, scenario);
            }
        }

        private static void CreateHexes(int rows, int columns)
        {
            var srcRect = GetSourceRectangle(TextureType.Hexagon);
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
                    var terrainType = TextureType.Woods;

                    //if(x == 5)
                    //{
                    //    terrainType = TerrainType.Dirt;
                    //}

                    //dict.Add(new Vector2(x, y), position);
                    var hex = new Hex(new Vector2(position.X, position.Y), new Vector2(x, y), terrainType, _hexScale);

                    EntityManager.Add(hex);

                    position.X += scaleWidth + (scaleWidth * 0.5f);
                }

                position.X = offset.X;
                position.Y += scaleHeight * 0.5f;
            }
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
