using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HexGame
{
    static class Input
    {
        private static MouseState _mouseState, _lastMouseState;
        public static Vector2 MousePosition => new Vector2(_mouseState.X, _mouseState.Y);
        public static int Radius = 10;
        public static void Update()
        {
            _lastMouseState = _mouseState;
            _mouseState = Mouse.GetState();
        }

        public static bool WasMouseLeftButtonPressed()
		{
            return _lastMouseState.LeftButton == ButtonState.Released && _mouseState.LeftButton == ButtonState.Pressed;
        }
    }
}

