using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UltraLight
{
    public class BattleState : State
    {
        public Hero hero;
        public Hud hud;
        public StarField starField;
        public EntityGroup entityGroup;

        public ProjectilePool projectilePool;

        public BattleState(StateStack stateStack)
        {
            entityGroup = new EntityGroup();
            hero = ShipDefs.UL1(64, 118, this);
            entityGroup.Add(hero);
            entityGroup.Add(ShipDefs.SB1(64, 20, this));
            hud = new Hud(hero);
            starField = new StarField();
            this.stateStack = stateStack;
            projectilePool = new ProjectilePool(this);
        }

        public override bool Update(float dt)
        {
            starField.Update(dt);
            entityGroup.Update(dt);
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
            entityGroup.Draw(spriteBatch);
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