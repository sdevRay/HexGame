using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.Entities
{
    abstract class Entity
    {
        protected Rectangle SourceRectangle;
        protected Color Color = Color.White;
        public Vector2 Position;
        public float Scale;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
