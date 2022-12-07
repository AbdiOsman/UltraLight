using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using UltraLight.Globals;
using UltraLight.States;

namespace UltraLight.Entities
{
    public class Baddie : Ship
    {
        public Animation anim;
        public float hitTime = 0.15f;
        public float hitTimer = 0f;
        public string objective;
        public float waitTime;
        public Vector2 targetPos = new Vector2();

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
            DoObjective(dt);
            if (position.Y > 160)
                remove = true;
        }

        private void DoObjective(float dt)
        {
            if (waitTime > 0f)
            {
                waitTime -= dt;
                return;
            }
            if (objective == "flyin")
            {
                position.X += (targetPos.X - position.X) * (1.6f * dt);
                position.Y += (targetPos.Y - position.Y) * (1.6f * dt);
                if (Math.Abs(position.Y - targetPos.Y) < 1)
                {
                    objective = "idle";
                }
            }
            else if (objective == "idle")
            {
            }
            else if (objective == "attack")
            {
                position.Y += speed * dt;
            }
        }

        public override void Shoot()
        {
        }

        public override void Collided()
        {
            if (hit is Projectile)
            {
                Projectile h = (Projectile)hit;
                hitTimer = hitTime;
                state.ShockW(h.position);
                state.HitSparks(h.position);
                hp--;
                Game1.sound.PlaySound("hit");
                if (hp <= 0)
                {
                    state.ShockW(position, true);
                    state.Explode(position);
                    state.Explode(position, false, true);
                    GameState.score++;
                    remove = true;
                }
                h.Reset();
            }
        }
    }
}