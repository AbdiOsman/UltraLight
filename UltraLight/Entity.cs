using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public abstract class Entity
    {
        public Texture2D sprite;
        public Vector2 position;
        public float speed = 80;
        public int width;
        public int height;
        public Rectangle rect;
        public Entity hit = null;
        public bool remove = false;

        public abstract void Update(float dt);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Move(float dt);

        public abstract void Collided();

        public void UpdateRectPos()
        {
            rect.X = (int)position.X;
            rect.Y = (int)position.Y;
        }
    }
}