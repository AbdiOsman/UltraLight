using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltraLight.Globals;
using UltraLight.States;

namespace UltraLight.Entities
{
    public abstract class Ship : Entity
    {
        public int hp;
        public int maxHp;
        public float projectileSpeed = 70f;
        public float fireRate = 0.15f;
        public float timer = 0;
        public Texture2D exhaust;
        public Animation exhaustAnim;
        public Rectangle[] quads;
        public BattleState state;
        public int damage = 1;
        public Texture2D projSprite;

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