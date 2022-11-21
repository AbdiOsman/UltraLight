using Microsoft.Xna.Framework;

namespace UltraLight
{
    public class Util
    {
        public static bool AABB(Vector2 a, Vector2 b)
        {
            float a_left = a.X;
            float a_top = a.Y;
            float a_right = a.X + 7;
            float a_bottom = a.Y + 7;

            float b_left = b.X;
            float b_top = b.Y;
            float b_right = b.X + 7;
            float b_bottom = b.Y + 7;

            if (a_top > b_bottom) return false;
            if (b_top > a_bottom) return false;
            if (a_left > b_right) return false;
            if (b_left > a_right) return false;

            return true;
        }
    }
}