using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace UltraLight
{
    public class ShipDefs
    {
        public static Dictionary<string, int[]> anims = new Dictionary<string, int[]>
        {
            ["exhaust1"] = new int[] { 0, 1, 0, 2, 0 },
            ["muzzle1"] = new int[] { 0, 1, 2, 3 }
        };

        public static Hero UL1(int x, int y, Texture2D sprite)
        {
            Hero newShip = new Hero(x, y, sprite);
            newShip.hp = 4;
            newShip.maxHp = 4;
            newShip.quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.exhaust = Game1.myContent.Load<Texture2D>("exhaust1");
            newShip.exhaustAnim = new Animation(anims["exhaust1"], true, 0.05f);
            newShip.muzzle = Game1.myContent.Load<Texture2D>("muzzle1");
            newShip.muzzleFlashAnim = new Animation(anims["muzzle1"], false, 0.05f, false);

            return newShip;
        }
    }
}