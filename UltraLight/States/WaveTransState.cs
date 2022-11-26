using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltraLight.Globals;

namespace UltraLight.States
{
    public class WaveTransState : State
    {
        public float timer = 3.15f;
        private BlinkingText blinkingText;

        public WaveTransState(StateStack stateStack)
        {
            this.stateStack = stateStack;
            blinkingText = new BlinkingText(2f, Color.White);
        }

        public override bool Update(float dt)
        {
            if (timer < 0)
            {
                stateStack.Pop();
            }

            blinkingText.Update(dt);
            timer -= dt;

            return true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            blinkingText.Draw(spriteBatch, "Wave " + GameState.wave, 64, 40, "center");
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            BattleState bs = (BattleState)stateStack.Top();
            bs.AddBaddies();
        }

        public override void HandleInput()
        {
        }
    }
}