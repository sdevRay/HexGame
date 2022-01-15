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

            Art.Load(Content);
            ScenarioManager.SetupHexagons();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            EntityManager.Draw(_spriteBatch);
            DrawText();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawText()
        {
            _spriteBatch.DrawString(Art.Font, Input.MousePosition.ToString(), new Vector2(20, 20), Color.White);
        }
    }
}

// https://github.com/sdevRay/ShapeBlaster/blob/master/ShapeBlaster/GameRoot.cs