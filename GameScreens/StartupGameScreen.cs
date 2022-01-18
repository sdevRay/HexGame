using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HexGame.GameScreens
{
	public class StartupGameScreen : GameScreen
	{
		private Texture2D _pixel;

		public StartupGameScreen()
		{
			
		}

		public override void LoadContent(GraphicsDevice device)
		{
			_pixel = new Texture2D(device, 1, 1);
			_pixel.SetData(new[] { Color.White });
		}

		public override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				quit = true;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_pixel, new Vector2(100, 100), Color.Yellow);
		}
	}
}
