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
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.exhaust = Game1.myContent.Load<Texture2D>("Art/exhaust1");
            newShip.exhaustAnim = new Animation(new int[] { 0, 1, 0, 2, 0 }, true, 0.05f);
            newShip.hp = 4;
            newShip.maxHp = 4;
            newShip.speed = 30;

            return newShip;
        }

        public static Baddie HC(int x, int y, BattleState state)
        {
            Baddie newShip = new Baddie(state);

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/baddie1");
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.hp = 5;
            newShip.maxHp = 5;
            newShip.speed = 20;
            newShip.anim = new Animation(new int[] { 0, 1, 2 }, true, 0.4f);

            return newShip;
        }

        public static Baddie OS(int x, int y, BattleState state)
        {
            Baddie newShip = new Baddie(state);

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/baddie2");
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.hp = 5;
            newShip.maxHp = 5;
            newShip.speed = 0;
            newShip.anim = new Animation(new int[] { 0, 1 }, true, 2f);

            return newShip;
        }

        public static Baddie RM(int x, int y, BattleState state)
        {
            Baddie newShip = new Baddie(state);

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/baddie3");
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.hp = 5;
            newShip.maxHp = 5;
            newShip.speed = 0;
            newShip.anim = new Animation(new int[] { 0, 1 }, true, 2f);

            return newShip;
        }

        public static Baddie DS(int x, int y, BattleState state)
        {
            Baddie newShip = new Baddie(state);

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 16, 16), new Rectangle(16, 0, 16, 16), new Rectangle(32, 0, 16, 16) };

            Texture2D sprite = Game1.myContent.Load<Texture2D>("Art/baddie4");
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.hp = 5;
            newShip.maxHp = 5;
            newShip.speed = 0;
            newShip.anim = new Animation(new int[] { 0, 1 }, true, 1.5f);

            return newShip;
        }
    }
}