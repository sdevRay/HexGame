using HexGame.Entities;
using HexGame.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Text;

namespace HexGame
{
	internal static class UserInterface
	{
		private static Rectangle DestinationRectangle;
		private static StringBuilder StringBuilder = new StringBuilder(); // this will be for a running console with update
		private static string Text = string.Empty;
		private static Texture2D Pixel;

		public static void SetupInfoBar(Texture2D pixel, int screenWidth, int screenHeight)
		{
			DestinationRectangle = new Rectangle(0, (int)(screenHeight * 0.85f), screenWidth, (int)(screenHeight * 0.25f));
			Pixel = pixel;
		}

		public static void SetHoverHex(Hex hex)
		{
			Text = hex.ToString();
		}

		public static void ClearHoverHex()
		{
			Text = string.Empty;
		}

		public static void Update()
		{

		}

		public static void Draw(SpriteBatch spriteBatch)
		{

			spriteBatch.Draw(Pixel, DestinationRectangle, Color.Black);

			spriteBatch.DrawString(Art.Font, Text, new Vector2(DestinationRectangle.X, DestinationRectangle.Y), Color.White);
			spriteBatch.DrawString(Art.Font, Input.MousePosition.ToString(), new Vector2(20, 20), Color.White);
		}

		//private void DrawRightAlignedString(string text, float y)
		//{
		//	var textWidth = Art.Font.MeasureString(text).X;
		//	_spriteBatch.DrawString(Art.Font, text, new Vector2(ScreenSize.X - textWidth - 5, y), Color.White);
		//}
	}
}
