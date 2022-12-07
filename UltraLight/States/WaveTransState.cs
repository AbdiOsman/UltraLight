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
            if (GameState.wave == 1)
                bs.BaddieFormation(new int[,] {
                   {-1,  0,  0,  0,  0,  0,  0,  0,  0, -1},
                   {-1,  0,  0,  0,  0,  0,  0,  0,  0, -1},
                   {-1,  0,  0,  0,  0,  0,  0,  0,  0, -1},
                   {-1,  0,  0,  0,  0,  0,  0,  0,  0, -1}
                });
            if (GameState.wave == 2)
                bs.BaddieFormation(new int[,] {
                    {0,  0,  1,  1,  0,  0,  1,  1,  0,  0},
                    {0,  0,  1,  1,  0,  0,  1,  1,  0,  0},
                    {0,  0,  1,  1,  1,  1,  1,  1,  0,  0},
                    {0,  0,  1,  1,  1,  1,  1,  1,  0,  0}
                });
            if (GameState.wave == 3)
                bs.BaddieFormation(new int[,] {
                    {2,  2, -1,  1,  1,  1,  1, -1,  2,  2},
                    {2,  2, -1,  1,  1,  1,  1, -1,  2,  2},
                    {2,  2, -1,  0,  0,  0,  0, -1,  2,  2},
                    {2,  2, -1,  0, -1, -1,  0, -1,  2,  2}
                });
            if (GameState.wave == 4)
                bs.BaddieFormation(new int[,] {
                    {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                    {-1, -1, -1, -1,  3, -1, -1, -1, -1, -1},
                    {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                    {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1}
                });
        }

        public override void HandleInput()
        {
        }
    }
}