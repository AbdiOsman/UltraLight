using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace UltraLight
{
    public class Particle
    {
        public Texture2D sprite;
        public Vector2 position;
        public Vector2 speed;
        public int width;
        public int height;

        public bool remove;
        public Random rnd;

        public Color color = Color.White;

        public Animation anim;

        public float time;
        public float timer;

        public Particle(Vector2 position)
        {
            sprite = Game1.myContent.Load<Texture2D>("Art/particle1");
            this.position = position;
            width = sprite.Width / 7;
            height = sprite.Height;
            rnd = new Random();
            speed.X = rnd.Next(-120, 120);
            speed.Y = rnd.Next(-120, 120);
            anim = new Animation(new int[] { 5, 4, 3, 2, 2, 1, 1, 0, 0 }, false, 0.04f);
            anim.index = (int)Util.GetRandomNumber(0, 5);
            timer = Util.GetRandomNumber(0, 0.14f);
            time = Util.GetRandomNumber(0.33f, 0.6f);
        }

        public void Update(float dt)
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), new Rectangle(anim.Frame() * width, 0, height, height), color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}