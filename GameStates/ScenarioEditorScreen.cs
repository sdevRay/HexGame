using HexGame.Managers;
using HexGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace HexGame.GameStates
{
    internal class ScenarioEditorScreen : GameState
    {
        private Texture2D _pixel;
        public Camera2D Camera { get; set; }

        public ScenarioEditorScreen(GraphicsDevice device) : base(device)
        {
        }

        public override void Initialize()
        {
            Camera = new Camera2D(GameRoot.Viewport, new Vector2(0, 0), 0.0f, 1.0f);
        }

        public override void LoadContent(ContentManager content)
        {
            Art.Load(content);

            _pixel = new Texture2D(_device, 1, 1);
            _pixel.SetData(new[] { Color.White });

            var test = new Scenario()
            {
                Columns = 5,
                Rows = 5,
                Description = "Fart",
                Title = "Tutle and styff",
                Hexes = ScenarioManager.CreateHexes(5, 5)
            };

            ScenarioManager.LoadScenario(test);
            UserInterface.SetupInfoBar(_pixel, GameRoot.ScreenSize);
        }

        public override void Update(GameTime gameTime)
        {
            Input.Update();
            Camera.Update(gameTime);
            EntityManager.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null,
                    null, null, null, Camera.GetTransformation(_device));

            EntityManager.Draw(spriteBatch);
            EntityManager.DrawTest(spriteBatch, _pixel);
            UserInterface.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void UnloadContent()
        {
        }
    }
}
