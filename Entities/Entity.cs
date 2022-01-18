using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.Entities
{
	public abstract class Entity
    {
        public Color Color = Color.White;
        public Vector2 Position;
        public float Scale;
        public float Radius = 20;

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
