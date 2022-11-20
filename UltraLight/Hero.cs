﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UltraLight
{
    public class Hero : Ship
    {
        public int direction = 1;

        public Hero(BattleState state) : base(state)
        {
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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(exhaust, new Vector2(position.X - width / 2, position.Y + height / 2), new Rectangle(exhaustAnim.Frame() * 8, 0, 8, 8), Color.White);

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
            UpdateRectPos();
        }

        public override void Shoot()
        {
            if (Input.Held(Keys.Z) && timer == 0)
            {
                state.projectilePool.SetProjectile(new Vector2(position.X, position.Y - height), new Vector2(0, -1), 150f);
                timer = fireRate;
            }
        }

        public override void Collided()
        {
            hp--;
        }
    }
}