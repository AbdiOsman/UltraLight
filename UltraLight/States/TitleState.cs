using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UltraLight.States
{
    public class TitleState : State
    {
        public Texture2D title;
        public StarField starField;
        public float fade = 1;
        public bool fadeout = true;
        public float speed = 0.5f;

        public TitleState(StateStack stateStack)
        {
            this.stateStack = stateStack;
            title = Game1.myContent.Load<Texture2D>("Art/title");
            starField = new StarField();
        }

        public override bool Update(float dt)
        {
            fade = fade + (fadeout ? -1 : 1) * speed * dt;
            if (fade <= 0.3)
                fadeout = false;
            if (fade >= 1)
                fadeout = true;

            starField.Update(dt);
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            starField.Draw(spriteBatch);
            spriteBatch.Draw(title, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Settings.defaultFont, "Press Z to Continue", new Vector2(64 - Settings.defaultFont.MeasureString("Press Z to Continue").X / 2, 64), Color.DeepSkyBlue * fade, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public override void HandleInput()
        {
            if (Input.JustReleased(Keys.Z))
            {
                stateStack.Pop();
            }
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            stateStack.Push(new BattleState(stateStack));
            stateStack.Push(new WaveTransState(stateStack));
        }
    }
}