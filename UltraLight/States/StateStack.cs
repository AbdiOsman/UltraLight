using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace UltraLight.States
{
    public class StateStack
    {
        public List<State> states = new List<State>();

        public void Update(float dt)
        {
            for (int i = states.Count - 1; i >= 0; i--)
            {
                State v = states[i];
                bool canContinue = v.Update(dt);
                if (!canContinue)
                {
                    break;
                }
            }

            State top = states[states.Count - 1];

            if (top == null)
                return;

            top.HandleInput();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (State state in states)
            {
                state.Draw(spriteBatch);
            }
        }

        public void Push(State state)
        {
            states.Add(state);
            state.Enter();
        }

        public State Pop()
        {
            State top = states[states.Count - 1];
            states.Remove(top);
            top.Exit();
            return top;
        }

        public State Top()
        {
            return states[states.Count - 1];
        }
    }
}