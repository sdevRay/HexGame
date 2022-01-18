using HexGame.Entities;
using HexGame.Managers;
using HexGame.Models;
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

        private Texture2D Pixel;

        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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

            Pixel = new Texture2D(GraphicsDevice, 1, 1);
            Pixel.SetData(new[] { Color.White });

            Art.Load(Content);
            UserInterface.SetupInfoBar(Pixel, _screenWidth, _screenHeight);

            var test = new Scenario()
            {
                Columns = 5,
                Rows = 5,
                Description = "Fart",
                Title = "Tutle and styff",
                Hexes = ScenarioManager.CreateHexes(5, 5)
            };

            // ScenarioManager.LoadScenario(test);
            //var scn = ScenarioManager.LoadFile("test1.xml");
            ScenarioManager.LoadScenario(test);
            //ScenarioManager.SaveFile(test);
            //ScenarioManager.CreateHexes(5, 5);

           // _hex = new Hex(new Vector2(0, 0), new Vector2(0, 0), Types.TextureType.Hexagon, 0.5f);
           // EntityManager.Add(hex);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Input.Update();
            EntityManager.Update();
            UserInterface.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            _spriteBatch.Begin();
            EntityManager.Draw(_spriteBatch);
            EntityManager.DrawTest(_spriteBatch, Pixel);
            UserInterface.Draw(_spriteBatch);
            _spriteBatch.End();

            //_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            //_spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

// https://github.com/sdevRay/ShapeBlaster/blob/master/ShapeBlaster/GameRoot.cs