using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace UltraLight
{
    internal class Baddie : Ship
    {
        public Baddie(int x, int y, Texture2D sprite)
        {
            position = new Vector2(x, y);
            this.sprite = sprite;
        }

        public override void Update(float dt)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Move(float dt)
        {
            throw new NotImplementedException();
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}