using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using UltraLight.Globals;

namespace UltraLight.UI
{
    public class FPS
    {
        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }

        public const int MAXIMUM_SAMPLES = 100;

        private Queue<float> _sampleBuffer = new Queue<float>();

        public void Update(float deltaTime)
        {
            CurrentFramesPerSecond = 1.0f / deltaTime;

            _sampleBuffer.Enqueue(CurrentFramesPerSecond);

            if (_sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                _sampleBuffer.Dequeue();
                AverageFramesPerSecond = _sampleBuffer.Average(i => i);
            }
            else
            {
                AverageFramesPerSecond = CurrentFramesPerSecond;
            }

            TotalFrames++;
            TotalSeconds += deltaTime;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var s = string.Format("FPS: {0}", AverageFramesPerSecond);
            spriteBatch.DrawString(Settings.defaultFont, s, new Vector2(2, 10), Color.White);
        }
    }
}