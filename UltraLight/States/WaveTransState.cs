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
            blinkingText.Draw(spriteBatch, "Wave " + GameData.wave, 64, 40, "center");
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            BattleState bs = (BattleState)stateStack.Top();
            if (GameData.wave == 1)
            {
                bs.baddieAttackTime = 2f;
                bs.baddieFireRate = 0.8f;
                bs.BaddieFormation(new int[,] {
                   {-1,  0,  0,  0,  0,  0,  0,  0,  0, -1},
                   {-1,  0,  0,  0,  0,  0,  0,  0,  0, -1},
                   {-1,  0,  0,  0,  0,  0,  0,  0,  0, -1},
                   {-1,  0,  0,  0,  0,  0,  0,  0,  0, -1}
                });
            }
            if (GameData.wave == 2)
            {
                bs.baddieAttackTime = 1.8f;
                bs.baddieFireRate = 0.7f;
                bs.BaddieFormation(new int[,] {
                    {0,  0,  1,  1,  0,  0,  1,  1,  0,  0},
                    {0,  0,  1,  1,  0,  0,  1,  1,  0,  0},
                    {0,  0,  1,  1,  1,  1,  1,  1,  0,  0},
                    {0,  0,  1,  1,  1,  1,  1,  1,  0,  0}
                });
            }
            if (GameData.wave == 3)
            {
                bs.baddieAttackTime = 1.3f;
                bs.baddieFireRate = 0.6f;
                bs.BaddieFormation(new int[,] {
                    {2,  2, -1,  1,  1,  1,  1, -1,  2,  2},
                    {2,  2, -1,  1,  1,  1,  1, -1,  2,  2},
                    {2,  2, -1,  0,  0,  0,  0, -1,  2,  2},
                    {2,  2, -1,  0,  0,  0,  0, -1,  2,  2}
                });
            }
            if (GameData.wave == 4)
            {
                bs.baddieAttackTime = 1f;
                bs.baddieFireRate = 0.5f;
                bs.BaddieFormation(new int[,] {
                    {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                    {-1, -1, -1,  3, -1, -1, 3,  -1, -1, -1},
                    {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
                    {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1}
                });
            }
        }

        public override void HandleInput()
        {
        }
    }
}