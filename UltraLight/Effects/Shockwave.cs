using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight.Effects
{
    public class Shockwave : Particle
    {
        public Animation anim;

        public Shockwave(Vector2 position, bool isBig = false)
        {
            if (isBig)
            {
                sprite = Game1.myContent.Load<Texture2D>("Art/shockwave2");
                width = sprite.Width / 12;
                anim = new Animation(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 11 }, false, 0.02f);
            }
            else
            {
                sprite = Game1.myContent.Load<Texture2D>("Art/shockwave1");
                width = sprite.Width / 4;
                anim = new Animation(new int[] { 0, 1, 2, 3, 3 }, false, 0.04f);
                color = new Color(255, 164, 1);
            }
            this.position = position;
            height = sprite.Height;
        }

        public override void Update(float dt)
        {
            anim.Update(dt);
            if (anim.IsFinished())
                remove = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), new Rectangle(anim.Frame() * width, 0, height, height), color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}