using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public class Hud
    {
        public int score = 5555;
        public int hp;
        public int maxhp;
        public Rectangle[] quads;
        public Texture2D heart;

        public Hud()
        {
            heart = Game1.myContent.Load<Texture2D>("heart");
            quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8)};
            hp = Game1.hero.hp;
            maxhp = Game1.hero.maxHp;
        }

        public void SetHp(int hp)
        {
            this.hp = hp;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            string scr = "SCORE:" + score.ToString();
            spriteBatch.DrawString(Settings.defaultFont, scr, new Vector2(64 - Settings.defaultFont.MeasureString(scr.ToString()).X/2, 2), Color.DeepSkyBlue);
            for (int i = 0; i < maxhp; i++)
            {
                if (hp > i)
                    spriteBatch.Draw(heart, new Vector2(2 + (2 * i) + 8 * i, 2), quads[1], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
                else
                    spriteBatch.Draw(heart, new Vector2(2 + (2 * i) + 8 * i, 2), quads[0], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            }
        }
    }
}
