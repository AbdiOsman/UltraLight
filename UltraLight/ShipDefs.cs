﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace UltraLight
{
    public class ShipDefs
    {
        public static Dictionary<string, int[]> anims = new Dictionary<string, int[]>
        {
            ["exhaust1"] = new int[] { 0, 1, 0, 2, 0 },
            ["muzzle1"] = new int[] { 0, 1, 2, 3 },
            ["baddie1-idle"] = new int[] { 0, 1, 2 }
        };

        public static Hero UL1(int x, int y)
        {
            Hero newShip = new Hero();

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            newShip = (Hero)NewShip(newShip, x, y, "hero", "exhaust1", quads);
            newShip.hp = 3;
            newShip.maxHp = 3;
            newShip.speed = 80;

            return newShip;
        }

        public static Baddie SB1(int x, int y)
        {
            Baddie newShip = new Baddie();

            Rectangle[] quads = new Rectangle[] { new Rectangle(0, 0, 8, 8), new Rectangle(8, 0, 8, 8), new Rectangle(16, 0, 8, 8) };

            newShip = (Baddie)NewShip(newShip, x, y, "baddie1", "exhaust1", quads);
            newShip.hp = 3;
            newShip.maxHp = 3;
            newShip.speed = 30;
            newShip.anim = new Animation(anims["baddie1-idle"], true, 0.4f);

            return newShip;
        }

        public static Ship NewShip(Ship newShip, float x, float y, string texture, string exhaust, Rectangle[] quads)
        {
            Texture2D sprite = Game1.myContent.Load<Texture2D>(texture);
            newShip.position = new Vector2(x, y);
            newShip.sprite = sprite;
            newShip.quads = quads;
            newShip.width = sprite.Width / newShip.quads.Length;
            newShip.height = sprite.Height;
            newShip.exhaust = Game1.myContent.Load<Texture2D>(exhaust);
            newShip.exhaustAnim = new Animation(anims[exhaust], true, 0.05f);

            return newShip;
        }
    }
}