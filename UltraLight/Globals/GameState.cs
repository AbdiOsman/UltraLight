namespace UltraLight.Globals
{
    public class GameState
    {
        public static int wave = 1;
        public static int score = 0;

        public static void Reset()
        {
            wave = 1;
            score = 0;
        }
    }
}