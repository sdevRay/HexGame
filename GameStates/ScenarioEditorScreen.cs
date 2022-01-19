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

        public ScenarioEditorScreen(GraphicsDevice device) : base(device)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            EntityManager.Draw(spriteBatch);
            EntityManager.DrawTest(spriteBatch, _pixel);
            spriteBatch.End();
        }

        public override void Initialize()
        {
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
        }

        public override void Update(GameTime gameTime)
        {
            Input.Update();
            EntityManager.Update();
        }

        public override void UnloadContent()
        {
        }
    }
}
