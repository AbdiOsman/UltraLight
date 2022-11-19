using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UltraLight
{
    internal class PauseState : State
    {
        public PauseState(StateStack stateStack)
        {
            this.stateStack = stateStack;
        }

        public override bool Update(float dt)
        {
            if (Input.JustPressed(Keys.P))
            {
                stateStack.Pop();
            }

            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Settings.defaultFont, "Paused", new Vector2(64 - Settings.defaultFont.MeasureString("Paused").X / 2, 64), Color.DeepSkyBlue, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
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