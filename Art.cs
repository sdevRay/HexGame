using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame
{
    static class Art
    {
        public static Texture2D TextureAtlas { get; private set; }
        //public static Texture2D HexagonTexture { get; private set; }
        public static SpriteFont Font { get; private set; }

        public static void Load(ContentManager content)
        {
            TextureAtlas = content.Load<Texture2D>("TextureAtlas");
            Font = content.Load<SpriteFont>("font");
            //HexagonTexture = content.Load<Texture2D>("hexagon");
        }
    }
}
