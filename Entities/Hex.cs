using HexGame.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace HexGame.Entities
{
    class Hex : Entity
    {
        public Vector2 Location;
        public TerrainType TerrainType;

        public Hex(Vector2 position, Vector2 location, TerrainType terrainType, float scale)
        {
            Position = position;
            Location = location;
            TerrainType = terrainType;
            Scale = scale;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Art.TextureAtlas, Position, ScenarioManager.GetSourceRectangle(TerrainType), Color, 0, new Vector2(0, 0), Scale, SpriteEffects.None,0);
            spriteBatch.Draw(Art.TextureAtlas, Position, ScenarioManager.GetSourceRectangle(TerrainType.Hexagon), Color, 0, new Vector2(0, 0), Scale, SpriteEffects.None, 1);
        }
    }
}
