namespace UltraLight.Globals
{
    public class GameData
    {
        public static int wave = 1;
        public static int score = 0;

        public static void Reset()
        {
            wave = 3;
            score = 0;
        }
    }
}