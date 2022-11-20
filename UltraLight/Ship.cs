using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public abstract class Ship : Entity
    {
        public int hp;
        public int maxHp;

        public float fireRate = 0.4f;
        public float timer = 0;

        public Texture2D exhaust;
        public Animation exhaustAnim;

        public Rectangle[] quads;

        public BattleState state;

        public Ship(BattleState state)
        {
            this.state = state;
        }

        public abstract void Shoot();

        public void Bounds()
        {
            if (position.X < width / 2)
            {
                position.X = width / 2;
            }
            else if (position.X > Settings.screenWidth - width / 2)
            {
                position.X = Settings.screenWidth - width / 2;
            }

            if (position.Y < height / 2)
            {
                position.Y = height / 2;
            }
            else if (position.Y > Settings.screenHeight - height / 2)
            {
                position.Y = Settings.screenHeight - height / 2;
            }
        }
    }
}