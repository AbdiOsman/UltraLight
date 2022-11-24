using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public class Explosion : Entity
    {
        public Animation anim = new Animation(new int[] { 0, 0, 1, 2, 3, 3, 4, 4, 5 }, false, 0.03f);
        public Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 16, 16), new Rectangle(16, 0, 16, 16), new Rectangle(32, 0, 16, 16), new Rectangle(48, 0, 16, 16), new Rectangle(64, 0, 16, 16) };

        public Explosion(Vector2 position)
        {
            sprite = Game1.myContent.Load<Texture2D>("Art/explosion1");
            this.position = position;
            width = this.sprite.Width / 5;
            height = this.sprite.Height;
        }

        public override void Update(float dt)
        {
            anim.Update(dt);
            if (anim.IsFinished())
                remove = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), quads[anim.Frame()], Color.White);
        }

        public override void Move(float dt)
        {
        }

        public override void Collided()
        {
        }
    }
}