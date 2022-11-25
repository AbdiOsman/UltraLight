using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UltraLight
{
    public class TransitionState : State
    {
        private StateStack StateStack;
        public float timer;

        public TransitionState(StateStack stateStack)
        {
            this.stateStack = stateStack;
        }

        public override bool Update(float dt)
        {
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
        
        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void HandleInput()
        {
        }
    }
}
