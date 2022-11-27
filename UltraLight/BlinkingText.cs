using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltraLight.Globals;

namespace UltraLight
{
    public class BlinkingText
    {
        public float fade = 0;
        public bool fadeout = false;
        public float speed;
        public string text;
        public Color color;

        public BlinkingText(float speed, Color color)
        {
            this.speed = speed;
            this.color = color;
        }

        public void Update(float dt)
        {
            fade = fade + (fadeout ? -1 : 1) * speed * dt;
            if (fade <= 0.3)
                fadeout = false;
            if (fade >= 1)
                fadeout = true;
        }

        public void Draw(SpriteBatch spriteBatch, string text, float x, float y, string align = "left")
        {
            Vector2 position = new Vector2(x, y);
            if (align == "center")
                position = new Vector2(x - Settings.defaultFont.MeasureString(text).X / 2, y);

            spriteBatch.DrawString(Settings.defaultFont, text, position, color * fade, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}