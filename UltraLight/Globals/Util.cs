using Microsoft.Xna.Framework;
using System;
using UltraLight.Entities;

namespace UltraLight.Globals
{
    public class Util
    {
        public static float GetRandomFloat(float minimum, float maximum)
        {
            Random random = new Random();
            return (float)(random.NextDouble() * (maximum - minimum) + minimum);
        }

        public static int GetRandomInt(int minimum, int maximum)
        {
            Random random = new Random();
            return random.Next(minimum, maximum);
        }
    }
}