using Microsoft.Xna.Framework.Input;

namespace UltraLight
{
    public class Input
    {
        private static KeyboardState currentKeyState;
        private static KeyboardState previousKeyState;

        public static KeyboardState GetState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
            return currentKeyState;
        }

        public static bool Held(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyDown(key);
        }

        public static bool JustPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
        }

        public static bool JustReleased(Keys key)
        {
            return !currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyDown(key);
        }

        public static Keys GetAny()
        {
            Keys[] pressedKeys = previousKeyState.GetPressedKeys();
            if (pressedKeys.Length > 0)
            {
                return pressedKeys[0];
            }
            return Keys.None;
        }
    }
}