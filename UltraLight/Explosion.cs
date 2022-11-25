using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public class Explosion : Particle
    {
        public bool isBlue;
        public bool isSpark;
        public Animation anim;
        public float time;
        public float timer;

        public Explosion(Vector2 position, bool isBlue = false, bool isSpark = false)
        {
            sprite = Game1.myContent.Load<Texture2D>("Art/particle1");
            this.position = position;
            width = sprite.Width / 7;
            height = sprite.Height;

            timer = Util.GetRandomNumber(0, 0.14f);
            time = Util.GetRandomNumber(0.10f, 0.6f);

            if (isSpark)
            {
                anim = new Animation(new int[] { 0, 0 }, false, 0.34f);
                speed.X = (int)Util.GetRandomNumber(-200, 200);
                speed.Y = (int)Util.GetRandomNumber(-200, 200);
            }
            else
            {
                anim = new Animation(new int[] { 5, 4, 3, 2, 2, 1, 1, 0, 0 }, false, 0.04f);
                anim.index = (int)Util.GetRandomNumber(0, 5);
                speed.X = (int)Util.GetRandomNumber(-120, 120);
                speed.Y = (int)Util.GetRandomNumber(-120, 120);
            }

            this.isBlue = isBlue;
            this.isSpark = isSpark;
        }

        public override void Update(float dt)
        {
            if (!isSpark)
            {
                if (isBlue == false)
                    setRed();
                else if (isBlue == true)
                    setBlue();
            }

            position += speed * dt;

            speed *= 0.88f;

            timer += dt;
            if (timer > time)
            {
                anim.Update(dt);
                if (anim.IsFinished())
                    remove = true;
            }
        }

        private void setRed()
        {
            if (timer > 0.16f)
            {
                color = new Color(255, 236, 41);
            }
            if (timer > 0.26f)
            {
                color = new Color(255, 164, 1);
            }
            if (timer > 0.36f)
            {
                color = new Color(255, 0, 77);
            }
            if (timer > 0.46f)
            {
                color = new Color(127, 37, 84);
            }
            if (timer > 0.6f)
            {
                color = new Color(97, 87, 81);
            }
        }

        private void setBlue()
        {
            if (timer > 0.16f)
            {
                color = new Color(195, 195, 201);
            }
            if (timer > 0.26f)
            {
                color = new Color(40, 172, 255);
            }
            if (timer > 0.36f)
            {
                color = new Color(131, 118, 156);
            }
            if (timer > 0.46f)
            {
                color = new Color(30, 43, 84);
            }
            if (timer > 0.6f)
            {
                color = new Color(30, 43, 84);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), new Rectangle(anim.Frame() * width, 0, height, height), color, 0, Vector2.Zero, 1f, SpriteEffects.None, isSpark ? 0.1f : 0);
        }
    }
}