using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace HexGame.GameStates
{
    public class GameStateManager
	{
		private static GameStateManager _instance;
		public static GameStateManager Instance 
		{
			get
            {
				if (_instance == null)
					_instance = new GameStateManager();
				
				return _instance;
			} 
		}

		private Stack<GameState> _screens = new Stack<GameState>();

		private ContentManager _content;

		public void SetContent(ContentManager content)
        {
			_content = content;
        }

		public void AddScreen(GameState gameState)
        {
            try
            {
				_screens.Push(gameState);
				_screens.Peek().Initialize();

				if(_content != null)
                {
					_screens.Peek().LoadContent(_content);
                }
            }
			catch(Exception)
            {

            }
        }

		public void RemoveScreen(GameState gameState)
        {
			if(_screens.Count > 0)
            {
                try
                {
					//var screen = _screens.Peek();
					_screens.Pop();
                }
				catch (Exception)
                {

                }
            }
        }

		public void ClearScreens()
        {
			_screens.Clear();

			//while(_screens.Count > 0)
            //{
				//_screens.Pop();
            //}
        }

		public void ChangeScreens(GameState screen)
        {
            try
            {
				_screens.Clear();
				AddScreen(screen);
            }
			catch(Exception)
            {

            }
        }

		public void Update(GameTime gameTime)
        {
            try
            {
                if(_screens.Count > 0)
                {
                    _screens.Peek().Update(gameTime);
                }
            }
            catch (Exception)
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Draw(spriteBatch);
                }
            }
            catch (Exception)
            {

            }
        }

        public void UnloadContent()
        {
            foreach(GameState state in _screens)
            {
                state.UnloadContent();
            }
        }

    }
}
