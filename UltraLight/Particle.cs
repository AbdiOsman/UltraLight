using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public abstract class Particle
    {
        public Texture2D sprite;
        public Vector2 position;
        public Vector2 speed = Vector2.Zero;
        public int width;
        public int height;
        public bool remove;
        public Color color = Color.White;

        public abstract void Update(float dt);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}