using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using UltraLight.Globals;
using UltraLight.Scenes;

namespace UltraLight.Entities
{
    public class Baddie : Ship
    {
        public Animation anim;
        public float hitTime = 0.15f;
        public float hitTimer = 0f;
        public string objective;
        public float waitTime;
        public int id;
        public float sx;
        public Vector2 targetPos = new Vector2();

        public Baddie(BattleScene state) : base(state)
        {
            projSprite = Game1.myContent.Load<Texture2D>("Art/bullet2");
            projectileSpeed = 20;
        }

        public override void Update(float dt)
        {
            anim.Update(dt);
            if (hitTimer > 0f)
            {
                hitTimer -= dt;
            }

            Move(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (hitTimer > 0f)
                Game1.ColorOverlay(Color.White);

            spriteBatch.Draw(sprite, new Vector2(position.X, position.Y), quads[anim.Frame()], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);

            Game1.RestartSpriteBatch();
        }

        public override void Move(float dt)
        {
            DoObjective(dt);
            if (position.Y > 160)
                remove = true;
        }

        public override void Shoot()
        {
            Projectile proj = new Projectile(position.X + width / 2, position.Y + height / 2, projectileSpeed, projSprite, new Vector2(0, 1));
            proj.IsBaddies();
            timer = fireRate;
            state.projectiles.Add(proj);
            group.Add(proj);
            hitTimer = 0.5f;
        }

        private void DoObjective(float dt)
        {
            if (waitTime > 0f)
            {
                waitTime -= dt;
                if (objective == "attack")
                {
                    if (id == 3)
                    {
                        anim.spf = 1.5f;
                        return;
                    }
                    sx += 0.2f;
                    Shake2(dt);
                }

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
                if (id == 0)
                {
                    sx += 0.05f;
                }
                if (id == 1)
                {
                    sx += 0.1f;
                }
                if (id == 2)
                {
                    if (anim.playing)
                    {
                        sx = 0;
                        anim.playing = false;
                        anim.index = anim.frames.Length - 1;
                    }
                    if (BattleScene.hero.position.Y <= position.Y)
                    {
                        if (sx == 0)
                        {
                            if (BattleScene.hero.position.Y <= position.Y)
                            {
                                speed = 0;
                                sx += (BattleScene.hero.position.X < position.X) ? -2 : 2;
                            }
                        }
                    }

                    if (position.X < -64)
                        remove = true;
                    if (position.X > 192)
                        remove = true;
                }
                BasicAttack(dt);
            }
        }

        public void BasicAttack(float dt)
        {
            Shake(dt);
            position.Y += speed * dt;
        }

        public void Shake(float dt)
        {
            float sx = ((float)Math.Sin(this.sx) / 2f);
            if (this.sx > 0 && speed != 0)
            {
                if (position.X < 32)
                    sx += 1 - (position.X / 32);
                if (position.X > 88)
                    sx -= (position.X - 88) / 32;
            }

            position.X += sx;
        }

        public void Shake2(float dt)
        {
            position.X += ((float)Math.Sin(this.sx) / 2f);
        }

        public override void Collided(Entity hit)
        {
            if (hit is Projectile)
            {
                Projectile h = (Projectile)hit;
                if (h.baddies) return;
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
                    GameData.score++;
                    if (objective == "attack")
                        state.baddieAttackTimer = state.baddieAttackTime;
                    remove = true;
                }
                h.Reset();
            }

            hit = null;
        }
    }
}