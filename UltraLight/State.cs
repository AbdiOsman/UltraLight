using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public abstract class State
    {
        public StateStack stateStack;

        public abstract bool Update(float dt);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void HandleInput();

        public abstract void Enter();

        public abstract void Exit();
    }
}