using HexGame.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HexGame.GameStates
{
	public class StartupGameScreen : GameState
	{
		private Texture2D _pixel;

        public StartupGameScreen(GraphicsDevice device) : base(device)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_pixel, new Vector2(100, 100), Color.Yellow);
            spriteBatch.End();
        }

        public override void Initialize()
        {
        }

        public override void LoadContent(ContentManager content)
        {
            	_pixel = new Texture2D(_device, 1, 1);
            	_pixel.SetData(new[] { Color.White });
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
