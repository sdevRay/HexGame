using HexGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HexGame
{
    public class GameRoot : Game
    {
        private GraphicsDeviceManager _graphics;
        private GraphicsDevice _device;
        private SpriteBatch _spriteBatch;

        private int _screenWidth;
        private int _screenHeight;



        private Hex[] _hexes;
        private float _hexScale;

        private const string _filePath = @"test.json";

        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // load file here

            //LoadMapFile();
            // map file is just a saved JSON, has location (0, 0) and terrain texture coordinates (or an enum value tied to these coordinates).
            // These details are plugged into the SetupHexagons method to set those values

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
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

           _hexScale = 0.1f;

            SetupHexagons();
        }


        public void SetupHexagons()
		{
            var cols = 8;
            var rows = 12;

            var scaleHeight = (int)(_hexTexture.Height * _hexScale);
            var scaleWidth = (int)(_hexTexture.Width * _hexScale);

            _hexes = new Hex[(cols * rows)];
            var index = 0;

            var offset = new Vector2(25, 25);
            var position = new Vector2(offset.X, offset.Y);

            // Save (X, Y) for each hex in a file
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (y % 2 == 0 && x == 0)
                    {
                        position.X += (scaleWidth * 3) / 4;
                    }

                    _hexes[index++] = new Hex() 
                    { 
                        Location = new Vector2(x, y),
                        Texture = _hexTexture, 
                        Position = new Vector2(position.X, position.Y),
                        TerrainTexure = _texture, // <- texture can come from somewhere else
                    };

                    position.X += scaleWidth + (scaleWidth * 0.5f);
                }

                position.X = offset.X;
                position.Y += scaleHeight * 0.5f;
            }

            FileManager.Write(_hexes);
        }

        public void DrawHexagons()
		{
            for(int i = 0; i < _hexes.Length; i++)
			{
                _spriteBatch.Draw(_hexes[i].TerrainTexure, _hexes[i].Position, null, _hexes[i].Color, 0, new Vector2(0, 0), _hexScale, SpriteEffects.None, 1);
                _spriteBatch.Draw(_hexes[i].Texture, _hexes[i].Position, null, _hexes[i].Color, 0, new Vector2(0, 0), _hexScale, SpriteEffects.None,1);

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
            _spriteBatch.DrawString(Art.Font, "Test", new Vector2(20, 20), Color.White);
        }
    }
}

// https://github.com/sdevRay/ShapeBlaster/blob/master/ShapeBlaster/GameRoot.cs