using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltraLight.Globals;

namespace UltraLight.Entities
{
    public class Projectile : Entity
    {
        public Vector2 direction;
        public bool baddies = false;
        public bool animated = false;
        public Animation anim = new Animation(new int[] { 0, 1, 2 }, true, 0.08f);
        public Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 6, 6), new Rectangle(6, 0, 6, 6), new Rectangle(12, 0, 6, 6) };

        public Projectile(float x, float y, float speed, Texture2D sprite, Vector2 direction)
        {
            position = new Vector2(x, y);
            this.speed = speed;
            this.sprite = sprite;
            width = sprite.Width;
            height = sprite.Height;
            this.direction = direction;
        }

        public override void Update(float dt)
        {
            anim.Update(dt);
            Move(dt);
            if (OutOfBounds())
            {
                Reset();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (animated)
                spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), quads[anim.Frame()], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
            else
                spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
        }

        public override void Move(float dt)
        {
            position += direction * (speed * dt);
        }

        public void IsHeroes()
        {
            baddies = false;
            animated = false;
            width = 8;
            height = 8;
        }

        public void IsBaddies()
        {
            baddies = true;
            animated = true;
            width = 6;
            height = 6;
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
            remove = true;
        }

        public override void Collided(Entity entity)
        {
        }
    }
}