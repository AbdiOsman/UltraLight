using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UltraLight.Globals;

namespace UltraLight.States
{
    public class GameOverState : State
    {
        BlinkingText blinkingText;

        public GameOverState(StateStack stateStack)
        {
            this.stateStack = stateStack;
            blinkingText = new BlinkingText(0.5f, new Color(255, 0, 77));
        }

        public override bool Update(float dt)
        {
            blinkingText.Update(dt);
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Settings.defaultFont, "GAME OVER", new Vector2(64 - Settings.defaultFont.MeasureString("GAME OVER").X / 2, 64 - 10), Color.DeepSkyBlue, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            blinkingText.Draw(spriteBatch, "PRESS Z TO CONTINUE", 64, 64, "center");
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