using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight.Entities
{
    public abstract class Entity
    {
        public Texture2D sprite;
        public Vector2 position;
        public float speed = 0;
        public int width;
        public int height;
        public EntityGroup group;
        public bool remove = false;

        public abstract void Update(float dt);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Move(float dt);

        public abstract void Collided(Entity entity);
    }
}