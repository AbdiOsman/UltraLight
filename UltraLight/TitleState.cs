using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace UltraLight
{
    public class TitleState : State
    {
        public Texture2D title;
        public StarField starField;

        public TitleState(StateStack stateStack)
        {
            this.stateStack = stateStack;
            title = Game1.myContent.Load<Texture2D>("title");
            starField = new StarField();
        }

        public override bool Update(float dt)
        {
            starField.Update(dt);
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            starField.Draw(spriteBatch);
            spriteBatch.Draw(title, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Settings.defaultFont, "Press Space to Continue", new Vector2(64 - Settings.defaultFont.MeasureString("Press Space to Continue").X / 2, 64), Color.DeepSkyBlue, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public override void HandleInput()
        {
            if (Input.JustPressed(Keys.Space))
            {
                stateStack.Pop();
                stateStack.Push(new BattleState(stateStack));
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