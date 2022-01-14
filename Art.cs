using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame
{
    static class Art
    {
        public static Texture2D Texture { get; private set; }
        public static Texture2D HexTexture { get; private set; }
        public static SpriteFont Font { get; private set; }

        public static void Load(ContentManager content)
        {
            Font = content.Load<SpriteFont>("font");
            HexTexture = content.Load<Texture2D>("hexagon");
            Texture = content.Load<Texture2D>("texture");
        }
    }
}
