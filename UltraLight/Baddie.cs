using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace UltraLight
{
    public class Baddie : Ship
    {
        public Animation anim;

        public Baddie(BattleState state) : base(state)
        {
        }

        public override void Update(float dt)
        {
            anim.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), quads[anim.Frame()], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
        }

        public override void Move(float dt)
        {
            position.Y += speed * dt;
            if (position.Y > 140)
                position.Y = -8;
        }

        public override void Shoot()
        {
        }

        public override void Collided()
        {
            if (hit is Projectile)
            {
                hp--;
                if (hp <= 0)
                {
                    hp = maxHp;
                    position.Y = -8;
                }
            }
        }
    }
}