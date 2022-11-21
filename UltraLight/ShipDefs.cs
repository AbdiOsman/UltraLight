using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace UltraLight
{
    public class ShipDefs
    {
        public static Dictionary<string, int[]> anims = new Dictionary<string, int[]>
        {
            ["exhaust1"] = new int[] { 0, 1, 0, 2, 0 },
            ["muzzle1"] = new int[] { 0, 1, 2, 3 },
            ["baddie1-idle"] = new int[] { 0, 1, 2 },
        };

        public static Hero UL1(int x, int y, BattleState state)
        {
            Hero newShip = new Hero(state);

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("hero");
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.exhaust = Game1.myContent.Load<Texture2D>("exhaust1");
            newShip.exhaustAnim = new Animation(anims["exhaust1"], true, 0.05f);
            newShip.hp = 4;
            newShip.maxHp = 4;
            newShip.speed = 30;

            return newShip;
        }

        public static Baddie HC(int x, int y, BattleState state)
        {
            Baddie newShip = new Baddie(state);

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("baddie1");
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.hp = 3;
            newShip.maxHp = 3;
            newShip.speed = 20;
            newShip.anim = new Animation(anims["baddie1-idle"], true, 0.4f);

            return newShip;
        }
    }
}