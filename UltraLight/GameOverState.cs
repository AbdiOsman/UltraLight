using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UltraLight
{
    internal class GameOverState : State
    {
        public GameOverState(StateStack stateStack)
        {
            this.stateStack = stateStack;
        }

        public override bool Update(float dt)
        {
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Settings.defaultFont, "GAME OVER", new Vector2(64 - Settings.defaultFont.MeasureString("GAME OVER").X / 2, 64 - 10), Color.DeepSkyBlue, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            spriteBatch.DrawString(Settings.defaultFont, "Press Z to Continue", new Vector2(64 - Settings.defaultFont.MeasureString("Press Z to Continue").X / 2, 64), Color.DeepSkyBlue, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public override void HandleInput()
        {
            if (Input.JustReleased(Keys.Z))
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