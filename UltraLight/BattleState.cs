﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace UltraLight
{
    public class BattleState : State
    {
        public Hero hero;
        public Hud hud;
        public StarField starField;
        public CollisionLayer entityGroup1;
        public CollisionLayer entityGroup2;
        public List<Baddie> baddies = new List<Baddie>();

        public ProjectilePool projectilePool;

        private Random rnd = new Random();

        public BattleState(StateStack stateStack)
        {
            entityGroup1 = new CollisionLayer();
            entityGroup2 = new CollisionLayer();

            rnd = new Random();

            hero = ShipDefs.UL1(64, 118, this);
            entityGroup1.Add(hero);

            AddBaddies();

            hud = new Hud(hero);
            starField = new StarField();

            projectilePool = new ProjectilePool(this);

            this.stateStack = stateStack;
        }

        public void AddBaddies()
        {
            for (int i = 0; i < 3; i++)
            {
                Baddie baddie = ShipDefs.HC(20 + i * 44, -rnd.Next(20, 128), this);
                baddies.Add(baddie);
                entityGroup1.Add(baddie);
                entityGroup2.Add(baddie);
            }
        }

        public override bool Update(float dt)
        {
            starField.Update(dt);
            entityGroup1.Update(dt);
            entityGroup2.Update(dt);
            if (Input.JustPressed(Keys.X))
            {
                hero.hp--;
            }
            if (hero.hp <= 0)
            {
                stateStack.Pop();
                stateStack.Push(new GameOverState(stateStack));
            }

            if (Input.JustPressed(Keys.P))
            {
                stateStack.Push(new PauseState(stateStack));
            }

            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            starField.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            foreach (Baddie baddie in baddies)
            {
                baddie.Draw(spriteBatch);
            }
            projectilePool.Draw(spriteBatch);
            hud.Draw(spriteBatch);
        }

        public override void HandleInput()
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}