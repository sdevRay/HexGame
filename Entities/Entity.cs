using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.Entities
{
    public abstract class Entity
    {
        public Color Color;
        public Vector2 ScreenCoordinates;
        public float Scale;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
