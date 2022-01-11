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
            var col = (int)(_screenWidth / (_hexTexture.Width * 0.2f));

            Debug.WriteLine(_screenWidth);
            Debug.WriteLine(_hexTexture.Width);
            Debug.WriteLine(col);

            _hexes = new Hex[(int)col];
            var xPos = 0;
            var yPos = 0;
            for (int i = 0; i < col; i++)
			{
                Debug.WriteLine(xPos);


                _hexes[i] = new Hex() { Position = new Vector2(xPos, yPos) };
                yPos += (int)((_hexTexture.Height * 0.2f) / 2);
                xPos += (int)(_hexTexture.Width * 0.2f) - (int)((_hexTexture.Width * 0.2f) / 4);
			}

        }

        public void DrawHexagons()
		{
            for(int i = 0; i < _hexes.Length; i++)
			{
                _spriteBatch.Draw(_hexTexture, _hexes[i].Position, null, Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1);
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
            //_spriteBatch.Draw(_hexTexture, new Vector2(0, 0), null, Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1);
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
