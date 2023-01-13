using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using UltraLight.States;

namespace UltraLight.Entities
{
    public class Hero : Ship
    {
        public int direction = 1;
        public float invTime = 2f;
        public float invTimer = 0;

        public Hero(BattleState state) : base(state)
        {
            projSprite = Game1.myContent.Load<Texture2D>("Art/bullet1");
        }

        public override void Update(float dt)
        {
            Move(dt);
            Bounds();
            Shoot();
            exhaustAnim.Update(dt);

            if (timer > 0)
                timer -= dt;
            else
                timer = 0;

            if (invTimer > 0)
                invTimer -= dt;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Math.Sin(invTimer * 20) > 0)
                return;

            spriteBatch.Draw(exhaust, new Vector2(position.X - width / 2, position.Y + height / 2), new Rectangle(exhaustAnim.Frame() * width, 0, width, height), Color.White);
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), quads[direction], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
        }

        public override void Move(float dt)
        {
            direction = 1;

            Vector2 input = Vector2.Zero;
            if (Input.Held(Keys.Left))
            {
                direction = 0;
                input.X--;
            }
            else if (Input.Held(Keys.Right))
            {
                direction = 2;
                input.X++;
            }

            if (Input.Held(Keys.Up))
            {
                input.Y--;
            }
            else if (Input.Held(Keys.Down))
            {
                input.Y++;
            }

            if (input != Vector2.Zero)
                input.Normalize();

            position += input * (speed * dt);
        }

        public override void Shoot()
        {
            if (Input.Held(Keys.Z) && timer == 0)
            {
                Projectile proj = new Projectile(position.X, position.Y - height, projectileSpeed, projSprite, new Vector2(0, -1));
                proj.IsHeroes();
                timer = fireRate;
                state.projectiles.Add(proj);
                state.entityGroup2.Add(proj);
            }
        }

        public override void Collided()
        {
            if (hit is Projectile)
            {
                Projectile h = (Projectile)hit;
                if (!h.baddies) return;
            }
            if (invTimer <= 0)
            {
                state.Explode(position, true);
                state.Explode(position, true, true);
                invTimer = invTime;
                hp--;

                Game1.sound.PlaySound("hurt");

                if (hp <= 0)
                    remove = true;
            }
            
        }
    }
}