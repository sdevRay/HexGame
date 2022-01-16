using HexGame.Managers;
using HexGame.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace HexGame.Entities
{
    public class Hex : Entity
    {
        public Vector2 Location;
        public TextureType TextureType;
        private Color HexagonColor = Color.Red;
        public Rectangle Bounds; 

        //private Rectangle SourceRectangle => ScenarioManager.GetSourceRectangle(TextureType);
        public Hex()
        {
        }

        public Hex(Vector2 position, Vector2 location, TextureType textureType, float scale)
        {
            Position = position;
            Location = location;
            TextureType = textureType;
            Scale = scale;

            var sourceRect = ScenarioManager.GetSourceRectangle(TextureType);
            var scaleWidth = sourceRect.Width * scale;
            var scaleHeight = sourceRect.Height * scale;
            Bounds = new Rectangle((int)Position.X + (int)scaleWidth / 4, (int)Position.Y, (sourceRect.Width / 2) - (int)scaleWidth / 4, sourceRect.Height / 2);
        }

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Art.TextureAtlas, Position, ScenarioManager.GetSourceRectangle(TextureType), Color, 0, new Vector2(0, 0), Scale, SpriteEffects.None,0);
            spriteBatch.Draw(Art.TextureAtlas, Position, ScenarioManager.GetSourceRectangle(TextureType.Hexagon), HexagonColor, 0, new Vector2(0, 0), Scale, SpriteEffects.None, 1);
        }

        public void DrawBoundingBox(SpriteBatch spriteBatch, Texture2D texture, Color color)
        {
            //_spriteBatch.Draw(whiteRectangle, new Rectangle(10, 20, 80, 30), Color.Chocolate);

            spriteBatch.Draw(texture, Bounds, new Color(color, 0.5f));
        }

        public void HandleCollisions()
        {
            Debug.WriteLine($"{Location} - {HexagonColor}");

            HexagonColor = Color.Red;
        }
    }
}
