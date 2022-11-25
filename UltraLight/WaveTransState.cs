using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public class WaveTransState : TransitionState
    {
        public float fade = 1;
        public bool fadeout = true;
        public float speed = 2f;
        public bool curt = false;

        public WaveTransState(StateStack stateStack) : base(stateStack)
        {
            timer = 3.15f;
        }

        public override bool Update(float dt)
        {

            fade = fade + ((fadeout ? -1 : 1) * speed * dt);
            if (fade <= 0.3)
                fadeout = false;
            if (fade >= 1)
                fadeout = true;

            if (timer < 0)
            {
                stateStack.Pop();
            }

            timer -= dt;

            return true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Settings.defaultFont, "Wave", new Vector2(64 - Settings.defaultFont.MeasureString("Wave").X / 2, 64), Color.DeepSkyBlue * fade, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
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
