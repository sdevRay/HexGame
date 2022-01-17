using HexGame.Managers;
using HexGame.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.Entities
{
    public class Hex : Entity
    {
        public Vector2 Location;
        public TextureType TextureType;
        public Color HexagonColor = Color.Black;
        public Rectangle Bounds;

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

            var sourceRect = ScenarioManager.GetSourceRectangle(TextureType);
            var scaleWidth = sourceRect.Width * Scale;
            var scaleHeight = sourceRect.Height * Scale;
            var boundingRect = new Rectangle(
                (int)Position.X + (int)(scaleWidth * 0.25f), 
                (int)Position.Y, 
                (int)scaleWidth - (int)(scaleWidth * 0.5f), 
                (int)scaleHeight
                );

            Bounds = boundingRect;
        }

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Art.TextureAtlas, Position, ScenarioManager.GetSourceRectangle(TextureType), Color, 0, new Vector2(0, 0), Scale, SpriteEffects.None,0);
            spriteBatch.Draw(Art.TextureAtlas, Position, ScenarioManager.GetSourceRectangle(TextureType.Hexagon), HexagonColor, 0, new Vector2(0, 0), Scale, SpriteEffects.None, 1);
            spriteBatch.DrawString(Art.Font, Location.ToString(), Position, Color.Black);

        }

        public void DrawBoundingBox(SpriteBatch spriteBatch, Texture2D texture, Color color)
        {
            spriteBatch.Draw(texture, Bounds, new Color(color, 0.25f));
        }

        public void HandleCollisions()
        {
            //Debug.WriteLine($"{Location} - {HexagonColor}");

            HexagonColor = Color.Red;
        }
    }
}
