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

        public Hex()
        {

        }

        public Hex(Vector2 position, Vector2 location, TextureType terrainType, float scale)
        {
            ScreenCoordinates = position;
            Location = location;
            TextureType = terrainType;
            Scale = scale;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Art.TextureAtlas, ScreenCoordinates, ScenarioManager.GetSourceRectangle(TextureType), Color, 0, new Vector2(0, 0), Scale, SpriteEffects.None,0);
            spriteBatch.Draw(Art.TextureAtlas, ScreenCoordinates, ScenarioManager.GetSourceRectangle(TextureType.Hexagon), Color, 0, new Vector2(0, 0), Scale, SpriteEffects.None, 1);
        }
    }
}
