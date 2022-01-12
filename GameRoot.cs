using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace HexGame
{
    public struct Hex
	{
        public Vector2 Position;
        public Texture2D Texture;
        public float Scale;
    }

    public class GameRoot : Game
    {
        private GraphicsDeviceManager _graphics;
        private GraphicsDevice _device;
        private SpriteBatch _spriteBatch;

        private int _screenWidth;
        private int _screenHeight;

        private Texture2D _hexTexture;
        private SpriteFont _font;

        private Hex[] _hexes;

        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            Window.Title = "HexGame";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _device = _graphics.GraphicsDevice;

            _screenWidth = _device.PresentationParameters.BackBufferWidth;
            _screenHeight = _device.PresentationParameters.BackBufferHeight;

            _font = Content.Load<SpriteFont>("font");
            _hexTexture = Content.Load<Texture2D>("hexagon");

            SetupHexagons();
        }

        public void SetupHexagons()
		{
            var offset = new Vector2(10, 10);

            var cols = 3;
            var rows = 3;

            var scaleHeight = _hexTexture.Height * 0.2f;
            var scaleWidth = (int)_hexTexture.Width * 0.2f;

            _hexes = new Hex[(cols * rows)];
            var num = 0;

            var position = new Vector2(0, 0); // <- this needs its own loop


				//Debug.WriteLine("DEBUG Y {0}, {1}", y, position.Y);
				for (int x = 0; x < cols; x++)
                {

                for (int y = 0; y < rows; y++)
                {
                }

                    _hexes[num++] = new Hex() { Position = new Vector2(position.X, position.Y) };

                    position.X += (int)(_hexTexture.Width * 0.1f) + ((int)(_hexTexture.Width * 0.1f) * 0.5f);

			    }


                //position.X = (int)(_hexTexture.Width * 0.1f) - (int)((_hexTexture.Height * 0.1f) / 4);
                position.X = ((int)(_hexTexture.Width * 0.1f) / 4) + ((int)(_hexTexture.Width * 0.1f) * 0.5f) * y;
                position.Y = (int)(_hexTexture.Height * 0.1f) - ((int)(_hexTexture.Height * 0.1f) * 0.5f);
			

		}

        public void DrawHexagons()
		{
            for(int i = 0; i < _hexes.Length; i++)
			{
                _spriteBatch.Draw(_hexTexture, _hexes[i].Position, null, Color.White, 0, new Vector2(0, 0), 0.1f, SpriteEffects.None, 1);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            DrawHexagons();
            DrawText();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawText()
        {
            _spriteBatch.DrawString(_font, "Test", new Vector2(20, 20), Color.White);
        }
    }
}
