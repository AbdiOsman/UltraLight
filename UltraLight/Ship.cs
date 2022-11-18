using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UltraLight
{
    public abstract class Ship
    {
        public Texture2D sprite;
        public Vector2 position;
        public int speed = 80;
        public int width;
        public int height;

        public int hp;
        public int maxHp;

        public KeyboardState kState;
        public float fireRate = 0.5f;
        public float timer = 0;

        public Texture2D exhaust;
        public Animation exhaustAnim;
        public Texture2D muzzle;
        public Animation muzzleFlashAnim;

        public abstract void Update(float dt);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Move(float dt);

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