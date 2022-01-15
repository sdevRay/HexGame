using HexGame.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace HexGame
{
    static class Art
    {
        public static Texture2D TerrainAtlas { get; private set; }
        public static Texture2D HexagonTexture { get; private set; }
        public static SpriteFont Font { get; private set; }

        public static void Load(ContentManager content)
        {
            TerrainAtlas = content.Load<Texture2D>("terrain_atlas");
            Font = content.Load<SpriteFont>("font");
            HexagonTexture = content.Load<Texture2D>("hexagon");
        }
    }
}
