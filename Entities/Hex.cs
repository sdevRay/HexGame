using HexGame.Managers;
using HexGame.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace HexGame.Entities
{
    public class Hex : Entity
    {
        public Vector2 Location;
        public TextureType TextureType;
        private Color HexagonColor = Color.Black;
        public Rectangle Bounds;
        public bool IsSelected;

        public Hex()
        {
        }

        public Hex(Vector2 position, Vector2 location, TextureType textureType, float scale)
        {
            Position = position;
            Location = location;
            TextureType = textureType;
            Scale = scale;

            SetBoundingRectangle();
        }

        public void SetBoundingRectangle()
        {
            var sourceRect = ScenarioManager.GetSourceRectangle(TextureType.Hexagon);
            var scaleWidth = sourceRect.Width * Scale;
            var scaleHeight = sourceRect.Height * Scale;
            var margin = 20;
            var boundingRect = new Rectangle(
                (int)Position.X + (int)(scaleWidth * 0.25f), 
                (int)Position.Y + margin, 
                (int)scaleWidth - (int)(scaleWidth * 0.5f), 
                (int)scaleHeight - (margin * 2)
                );

            Bounds = boundingRect;
        }

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Art.TextureAtlas, Position, ScenarioManager.GetSourceRectangle(TextureType), Color, 0, new Vector2(0, 0), Scale, SpriteEffects.None,0);        
            spriteBatch.Draw(Art.TextureAtlas, Position, ScenarioManager.GetSourceRectangle(TextureType.Hexagon), HexagonColor, 0, new Vector2(0, 0), Scale, SpriteEffects.None, 1);
        }

        public void DrawBoundingBox(SpriteBatch spriteBatch, Texture2D pixel, Color color)
        {
            spriteBatch.Draw(pixel, Bounds, new Color(color, 0.25f));
        }

        public void HandlePointHover(bool isPointHover)
        {
            if (isPointHover)
            {
                HexagonColor = Color.Red;
                UserInterface.SetHoverHex(this);
            }
			else
			{
                if(HexagonColor != Color.Black)
				{
                    HexagonColor = Color.Black;
                    UserInterface.ClearHoverHex();
				}
            }          
        }

		public override string ToString()
		{
            var sb = new StringBuilder();
            sb.AppendLine(Location.ToString());
            sb.AppendLine(TextureType.ToString());
            return sb.ToString();
		}
	}
}
