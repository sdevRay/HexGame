using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.GameScreens
{
	public abstract class GameScreen
	{
		protected bool Initialized;
		protected bool Quit;

		public virtual void Initialize()
		{
			Initialized = true;
		}

		public abstract void LoadContent(GraphicsDevice device);

		public abstract void Update(GameTime gameTime);

		public abstract void Draw(SpriteBatch spriteBatch);
	}
}
