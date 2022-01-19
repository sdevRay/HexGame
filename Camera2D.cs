using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame
{
	public class Camera2D
	{
		public Vector2 Position { get; set; }
		public float Rotation { get; set; }
		public float Zoom { get; set; }
		public Vector2 Origin { get; set; }



		private float maxZoom;
		private float minZoom;
		private int width;
		private int height;
		private Matrix transform;
		private float zoom;

		public Camera2D(Viewport viewport, Vector2 position, float rotation, float zoom)
		{
			Position = position;
			Rotation = rotation;
			Zoom = zoom;
			Origin = new Vector2(viewport.Width / 2.0f, viewport.Height / 2.0f);
			height = viewport.Height;
			width = viewport.Width;
		}

		public void Update(GameTime gameTime)
		{
			Position += Input.GetKeyboardDirection();
		}

		public Matrix GetTransformation(GraphicsDevice graphicsDevice)
		{
			Matrix transform = Matrix.CreateTranslation(new Vector3(-Position, 0)) *
			Matrix.CreateRotationZ(Rotation) *
			Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
			Matrix.CreateTranslation(new Vector3(Origin, 0));

			return transform;
		}
	}
}
