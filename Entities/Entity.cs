using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.Entities
{
    abstract class Entity
    {
        protected Texture2D Texture;
        protected Color Color = Color.White;
        public Vector2 Position;
        public float Scale;

        public abstract void Update(GameTime gameTime);
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color);
        }
    }
}
