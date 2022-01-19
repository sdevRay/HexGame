using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.Entities
{
	public abstract class Entity
    {
        protected Color Color = Color.White;
        protected Vector2 Position;
        protected float Scale;

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
