using HexGame.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame
{
    public class GameRoot : Game
    {
        public static GameRoot Instance { get; private set; }
        public static Vector2 ScreenSize => new Vector2(Instance._graphics.PreferredBackBufferWidth, Instance._graphics.PreferredBackBufferHeight);
        public static Viewport Viewport => Instance._device.Viewport;

        private GraphicsDeviceManager _graphics;
        private GraphicsDevice _device;
        private SpriteBatch _spriteBatch;

        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            Instance = this;
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

            GameStateManager.Instance.SetContent(Content);
            GameStateManager.Instance.AddScreen(new ScenarioEditorScreen(_device));
        }

        protected override void UnloadContent()
        {
            GameStateManager.Instance.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            GameStateManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GameStateManager.Instance.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}