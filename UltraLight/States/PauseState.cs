using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UltraLight.Globals;

namespace UltraLight.States
{
    public class PauseState : State
    {
        public PauseState(StateStack stateStack)
        {
            this.stateStack = stateStack;
        }

        public override bool Update(float dt)
        {
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Settings.defaultFont, "PUASED", new Vector2(64 - Settings.defaultFont.MeasureString("PAUSED").X / 2, 64), Color.DeepSkyBlue, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            spriteBatch.DrawString(Settings.defaultFont, "PRESS X TO QUIT", new Vector2(64 - Settings.defaultFont.MeasureString("PRESS X TO QUIT").X / 2, 74), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public override void HandleInput()
        {
            if (Input.JustPressed(Keys.P))
            {
                stateStack.Pop();
            }

            if (Input.JustReleased(Keys.X))
            {
                stateStack.Pop();
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