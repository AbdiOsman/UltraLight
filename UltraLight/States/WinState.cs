using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UltraLight.Globals;

namespace UltraLight.States
{
    internal class WinState : State
    {
        private BlinkingText blinkingText;

        public WinState(StateStack stateStack)
        {
            this.stateStack = stateStack;
            blinkingText = new BlinkingText(0.5f, new Color(242, 229, 220));
        }

        public override bool Update(float dt)
        {
            blinkingText.Update(dt);
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Settings.defaultFont, "YOU WIN!", new Vector2(64 - Settings.defaultFont.MeasureString("YOU WIN!").X / 2, 64 - 10), new Color(0, 231, 86), 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            blinkingText.Draw(spriteBatch, "PRESS C TO CONTINUE", 64, 64, "center");
        }

        public override void HandleInput()
        {
            if (Input.JustPressed(Keys.C))
            {
                stateStack.Pop();
                stateStack.Push(new TitleState(stateStack));
            }
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}