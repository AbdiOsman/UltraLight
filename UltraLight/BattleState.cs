using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UltraLight
{
    public class BattleState : State
    {
        public static Hero hero;
        public Hud hud;
        public StarField starField;

        public BattleState(StateStack stateStack)
        {
            hero = ShipDefs.UL1(64, 118);
            hud = new Hud(hero);
            starField = new StarField();
            this.stateStack = stateStack;
        }

        public override bool Update(float dt)
        {
            starField.Update(dt);
            hero.Update(dt);

            if (Input.JustPressed(Keys.X))
            {
                hero.hp--;
                hud.SetHp(hero.hp);
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