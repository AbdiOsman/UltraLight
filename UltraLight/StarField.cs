using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace UltraLight
{
    public class StarField
    {
        private Texture2D star;
        private Vector2[] positions;
        private int[] speeds;
        private int numOfStarts = 100;
        private int speedMin = 25;
        private int speedMax = 50;
        private Random rnd = new Random();

        private Color color1 = new Color(255, 255, 255);
        private Color color2 = new Color(131, 131, 154);
        private Color color3 = new Color(65, 65, 65);

        public StarField()
        {
            star = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            star.SetData(new Color[] { Color.White });

            positions = new Vector2[numOfStarts];
            speeds = new int[numOfStarts];
            for (int i = 0; i < numOfStarts; i++)
            {
                positions[i] = new Vector2(rnd.Next(Settings.screenWidth + 1), rnd.Next(Settings.screenWidth + 1));
                speeds[i] = rnd.Next(speedMin, speedMax + 1);
            }
        }

        public void Update(float dt)
        {
            for (int i = 0; i < numOfStarts; i++)
            {
                positions[i].Y += speeds[i] * dt;
                if (positions[i].Y > Settings.screenWidth)
                {
                    positions[i].X = rnd.Next(0, Settings.screenWidth + 1);
                    positions[i].Y = -4;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < numOfStarts; i++)
            {
                Color color = color1;

                if (speeds[i] <= 25)
                    color = color3;
                else if (speeds[i] <= 40)
                    color = color2;

                spriteBatch.Draw(star, positions[i], null, color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}