using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UltraLight.Effects;
using UltraLight.UI;

namespace UltraLight.Scenes
{
    public class TitleScene : State
    {
        public Texture2D title;
        public StarField starField;
        public BlinkingText blinkingText;

        public TitleScene(StateStack stateStack)
        {
            this.stateStack = stateStack;
            title = Game1.myContent.Load<Texture2D>("Art/title");
            starField = new StarField();
            blinkingText = new BlinkingText(0.5f, new Color(242, 229, 220));
        }

        public override bool Update(float dt)
        {
            starField.Update(dt);
            blinkingText.Update(dt);
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            starField.Draw(spriteBatch);
            spriteBatch.Draw(title, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            blinkingText.Draw(spriteBatch, "PRESS C TO CONTINUE", 64, 64, "center");
        }

        public override void HandleInput()
        {
            if (Input.JustPressed(Keys.C))
            {
                stateStack.Pop();
                stateStack.Push(new BattleScene(stateStack));
                stateStack.Push(new WaveTransScene(stateStack));
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