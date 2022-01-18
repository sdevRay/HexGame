using HexGame.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace HexGame.Managers
{
	public static class GameScreenManager
	{
		private static Stack<GameScreen> _gameScreens = new Stack<GameScreen>();
		//public Stack<GameScreen> GameScreens { get { return _gameScreens;  } }

		public static void Update(GameTime gameTime)
		{
			bool gameScreenPopped = false;

			do
			{
				gameScreenPopped = false;

				if (_gameScreens.Count == 0)
				{
					GameRoot.Instance.Exit();
					return; // <-- THIS DOESN'T SEEM RIGHT?
				}

				var gs = _gameScreens.Peek();
				if (gs.IsInitialized == false)
				{
					gs.Initialize();
					gs.LoadContent(GameRoot.Instance.GraphicsDevice);
				}

				gs.Update(gameTime);
				if (gs.IsQuit)
				{
					_gameScreens.Pop();
					gameScreenPopped = true;
				}

			} while (gameScreenPopped);
		}

		public static void Draw(SpriteBatch spriteBatch)
		{
			_gameScreens.Peek().Draw(spriteBatch);
		}
		public static void Push(GameScreen gameScreen)
		{
			_gameScreens.Push(gameScreen);
		}
	}
}
