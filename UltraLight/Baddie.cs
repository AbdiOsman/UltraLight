using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public class Baddie : Ship
    {
        public Animation anim;
        public float hitTime = 0.15f;
        public float hitTimer = 0f;

        public Baddie(BattleState state) : base(state)
        {
        }

        public override void Update(float dt)
        {
            anim.Update(dt);
            if (hitTimer > 0f)
            {
                hitTimer -= dt;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (hitTimer > 0f)
                Game1.ColorOverlay(Color.White);

            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), quads[anim.Frame()], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);

            Game1.RestartSpriteBatch();
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
                hitTimer = hitTime;
                hp--;
                if (hp <= 0)
                {
                    state.Explode(position);
                    hp = maxHp;
                    position.Y = -40;
                }
            }
        }
    }
}