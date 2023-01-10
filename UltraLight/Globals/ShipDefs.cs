using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltraLight.Entities;
using UltraLight.States;

namespace UltraLight.Globals
{
    public class ShipDefs
    {
        public static Hero UL1(int x, int y, BattleState state)
        {
            Hero newShip = new Hero(state);

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/hero");
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = 8;
            newShip.height = 8;
            newShip.exhaust = Game1.myContent.Load<Texture2D>("Art/exhaust1");
            newShip.exhaustAnim = new Animation(new int[] { 0, 1, 0, 2, 0 }, true, 0.05f);
            newShip.hp = 4;
            newShip.maxHp = 4;
            newShip.speed = 30;

            return newShip;
        }

        public static Baddie HG(int x, int y, Baddie newShip)
        {
            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/baddie1");
            newShip.id = 0;
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = 8;
            newShip.height = 8;
            newShip.hp = 1;
            newShip.speed = 20;
            newShip.anim = new Animation(new int[] { 0, 1, 2 }, true, 0.4f);

            return newShip;
        }

        public static Baddie CR(int x, int y, Baddie newShip)
        {
            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/baddie2");
            newShip.id = 1;
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = 8;
            newShip.height = 8;
            newShip.hp = 1;
            newShip.speed = 30;
            newShip.anim = new Animation(new int[] { 0, 1, }, true, 0.6f);

            return newShip;
        }

        public static Baddie RM(int x, int y, Baddie newShip)
        {
            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/baddie3");
            newShip.id = 2;
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = 8;
            newShip.height = 8;
            newShip.hp = 1;
            newShip.speed = 20;
            newShip.anim = new Animation(new int[] { 0, 1 }, true, 0.6f);

            return newShip;
        }

        public static Baddie DS(int x, int y, Baddie newShip)
        {
            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 16, 16), new Rectangle(16, 0, 16, 16), new Rectangle(32, 0, 16, 16) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/baddie4");
            newShip.id = 3;
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = 16;
            newShip.height = 16;
            newShip.hp = 1;
            newShip.speed = 0;
            newShip.anim = new Animation(new int[] { 0, 1 }, true, 1.5f);
            newShip.anim.delayedStart = Util.GetRandomFloat(0.1f, 0.2f);

            return newShip;
        }
    }
}