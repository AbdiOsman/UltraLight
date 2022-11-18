using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace UltraLight
{
    public class Hero : Ship
    {
        public int direction = 1;
        
        public Rectangle[] quads;

        public Hero(int x, int y, Texture2D sprite)
        {
            position = new Vector2(x, y);
            this.sprite = sprite;
        }

        public override void Update(float dt)
        {
            Move(dt);
            Bounds();
            Shoot();
            exhaustAnim.Update(dt);
            muzzleFlashAnim.Update(dt);

            if (muzzleFlashAnim.IsFinished())
            {
                muzzleFlashAnim.start = false;
            }

            if (timer > 0)
                timer -= dt;
            else
                timer = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(exhaust, new Vector2(position.X - width / 2, position.Y + height / 2), new Rectangle(exhaustAnim.Frame() * 8, 0, 8, 8), Color.White);

            if (muzzleFlashAnim.start && muzzleFlashAnim.IsFinished() == false)
            {
                spriteBatch.Draw(muzzle, new Vector2(position.X - width / 2, position.Y - height), new Rectangle(muzzleFlashAnim.Frame() * 8, 0, 8, 8), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.5f);
            }
            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), quads[direction], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
        }

        public override void Move(float dt)
        {
            kState = Keyboard.GetState();
            direction = 1;

            Vector2 input = Vector2.Zero;
            if (kState.IsKeyDown(Keys.Left))
            {
                direction = 0;
                input.X--;
            }
            else if (kState.IsKeyDown(Keys.Right))
            {
                direction = 2;
                input.X++;
            }

            if (kState.IsKeyDown(Keys.Up))
            {
                input.Y--;
            }
            else if (kState.IsKeyDown(Keys.Down))
            {
                input.Y++;
            }

            if (input != Vector2.Zero)
                input.Normalize();

            position += input * (speed * dt);
        }

        public override void Shoot()
        {
            kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.Z) && timer == 0)
            {
                Game1.projectilePool.SetProjectile(new Vector2(position.X, position.Y - height), new Vector2(0, -1), 150f);
                timer = fireRate;
                muzzleFlashAnim.index = 0;
                muzzleFlashAnim.start = true;
            }
        }
    }
}