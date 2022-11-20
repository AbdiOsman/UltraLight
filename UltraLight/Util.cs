using Microsoft.Xna.Framework;

namespace UltraLight
{
    public class Util
    {
        public static bool Collides(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }
    }
}