using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.GameStates
{
    public abstract class GameState : IGameState
    {
        protected GraphicsDevice _device;

        public GameState(GraphicsDevice device)
        {
            _device = device;
        }

        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void UnloadContent();
    }
}
