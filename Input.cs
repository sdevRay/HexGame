using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HexGame
{
    static class Input
    {
        private static MouseState _mouseState, _lastMouseState;
        private static KeyboardState _keyboardState, _lastKeyboardState;
        public static Vector2 MousePosition => new Vector2(_mouseState.X, _mouseState.Y);

        public static void Update()
        {
            _lastMouseState = _mouseState;
            _mouseState = Mouse.GetState();

            _lastKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();
        }

        public static Vector2 GetKeyboardDirection()
		{
            var direction = new Vector2();

			if (_keyboardState.IsKeyDown(Keys.A))
			{
				direction.X += 5;
			}

			if (_keyboardState.IsKeyDown(Keys.D))
			{
				direction.X -= 5;
			}

			if (_keyboardState.IsKeyDown(Keys.W))
			{
				direction.Y += 5;
			}

			if (_keyboardState.IsKeyDown(Keys.S))
			{
				direction.Y -= 5;
			}


			if (direction == Vector2.Zero)
			{
				return Vector2.Zero;
			}
			else
			{
				return Vector2.Normalize(direction);
			}
		}

        public static bool WasMouseLeftButtonPressed()
		{
            return _lastMouseState.LeftButton == ButtonState.Released && _mouseState.LeftButton == ButtonState.Pressed;
        }
    }
}

