using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public class Projectile
    {
        public Texture2D sprite;
        public Vector2 position;
        public Vector2 direction;
        public float speed;
        public int width;
        public int height;

        public Projectile(int x, int y, float speed, Texture2D sprite)
        {
            position = new Vector2(x, y);
            this.speed = speed;
            this.sprite = sprite;
            width = sprite.Width;
            height = sprite.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
        }

        public void Move(Vector2 direction, float dt)
        {
            this.direction = direction;
            position += direction * (speed * dt);
        }

        public bool OutOfBounds()
        {
            return position.X < -width || position.X > Settings.screenWidth + width || position.Y < -height || position.Y > Settings.screenHeight + height;
        }
    }
}