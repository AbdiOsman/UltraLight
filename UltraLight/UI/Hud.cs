using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltraLight.Entities;
using UltraLight.Globals;

namespace UltraLight.UI
{
    public class Hud
    {
        public Rectangle[] quads;
        public Texture2D heart;
        public Hero hero;
        public Color color = new Color(40, 172, 255);

        public Hud(Hero hero)
        {
            heart = Game1.myContent.Load<Texture2D>("Art/heart");
            quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8) };
            this.hero = hero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            string scr = "SCORE:" + GameState.score.ToString();
            spriteBatch.DrawString(Settings.defaultFont, scr, new Vector2(64 - Settings.defaultFont.MeasureString(scr.ToString()).X / 2, 2), color);
            for (int i = 0; i < hero.maxHp; i++)
            {
                if (hero.hp > i)
                    spriteBatch.Draw(heart, new Vector2(2 + 2 * i + 8 * i, 2), quads[1], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.99f);
                else
                    spriteBatch.Draw(heart, new Vector2(2 + 2 * i + 8 * i, 2), quads[0], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.99f);
            }
        }
    }
}