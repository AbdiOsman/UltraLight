using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace UltraLight
{
    public class ProjectilePool
    {
        public Projectile[] projectiles = new Projectile[50];
        private int index = 0;
        public BattleState battleState;

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>
        {
            ["bullet1"] = Game1.myContent.Load<Texture2D>("bullet1")
        };

        public ProjectilePool(BattleState battleState)
        {
            for (int i = 0; i < projectiles.Length; i++)
            {
                projectiles[i] = new Projectile(-50, -50, 0, textures["bullet1"]);
            }

            this.battleState = battleState;
        }

        public Projectile SetProjectile(Vector2 position, Vector2 directon, float speed, string sprite = "bullet1")
        {
            int i = index;
            projectiles[index].position = position;
            projectiles[index].direction = directon;
            projectiles[index].speed = speed;
            projectiles[index].sprite = textures[sprite];

            index = (index + 1) % (projectiles.Length);
            return projectiles[i];
        }

        public void Update(float dt)
        {
            foreach (Projectile projectile in projectiles)
            {
                projectile.Update(dt);
            }

            for (int i = projectiles.Length - 1; i >= 0; i--)
            {
                if (projectiles[i].OutOfBounds())
                {
                    projectiles[i].speed = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }
    }
}