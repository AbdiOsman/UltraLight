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
            exhaustAnim.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(exhaust, new Vector2(position.X + width / 2, position.Y - height / 2), new Rectangle(exhaustAnim.Frame() * 8, 0, 8, 8), Color.White, (float)(Math.PI / 180) * 180, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);

            spriteBatch.Draw(sprite, new Vector2(position.X - width / 2, position.Y - height / 2), quads[anim.Frame()], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
        }

        public override void Move(float dt)
        {
            position.Y += speed * dt;
            UpdateRectPos();
        }

        public override void Shoot()
        {
        }

        public override void Collided()
        {
            hp--;
            if (hp <= 0)
                remove = true;
        }
    }
}