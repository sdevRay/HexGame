using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HexGame.Entities
{
    class Hex : Entity
    {
        public Vector2 Location;
        public Texture2D TerrainTexure;
        public float Scale = 0.1f;

        public Hex(Texture2D texture, Vector2 position)
        {
            
        }
    }
}
