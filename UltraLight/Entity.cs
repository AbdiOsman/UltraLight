using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public abstract class Entity
    {
        public Texture2D sprite;
        public Vector2 position;
        public float speed = 0;
        public int width;
        public int height;
        public Entity hit = null;
        public bool remove = false;

        public abstract void Update(float dt);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Move(float dt);

        public abstract void Collided();
    }
}