using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltraLight.Globals;

namespace UltraLight.Entities
{
    public class Projectile : Entity
    {
        public Vector2 direction;

        public Projectile(int x, int y, float speed, Texture2D sprite)
        {
            position = new Vector2(x, y);
            this.speed = speed;
            this.sprite = sprite;
            width = sprite.Width;
            height = sprite.Height;
        }

        public override void Update(float dt)
        {
            Move(dt);
            if (OutOfBounds())
            {
                Reset();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
        }

        public override void Move(float dt)
        {
            position += direction * (speed * dt);
        }

        public bool OutOfBounds()
        {
            return position.X < -width || position.X > Settings.screenWidth + width || position.Y < -height || position.Y > Settings.screenHeight + height;
        }

        public void Reset()
        {
            position.X = -5000;
            position.Y = -5000;
            speed = 0;
        }

        public override void Collided()
        {
        }
    }
}