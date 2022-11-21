using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UltraLight
{
    public class BattleState : State
    {
        public Hero hero;
        public Hud hud;
        public StarField starField;
        public EntityGroup entityGroup1;
        public EntityGroup entityGroup2;

        public ProjectilePool projectilePool;

        public BattleState(StateStack stateStack)
        {
            entityGroup1 = new EntityGroup();
            entityGroup2 = new EntityGroup();
            hero = ShipDefs.UL1(64, 118, this);
            Baddie baddie = ShipDefs.SB1(64, 20, this);
            entityGroup1.Add(hero);
            entityGroup1.Add(baddie);
            entityGroup2.Add(baddie);
            hud = new Hud(hero);
            starField = new StarField();
            this.stateStack = stateStack;
            projectilePool = new ProjectilePool(this);
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
            entityGroup1.Draw(spriteBatch);
            entityGroup2.Draw(spriteBatch);
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