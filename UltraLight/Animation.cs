using System;

namespace UltraLight
{
    public class Animation
    {
        public bool loop = false;
        public int[] frames;
        public float spf;
        public float time;
        public bool playing;
        public int index;
        public float delayedStart = 0;

        public Animation(int[] frames, bool loop = true, float spf = 0.2f, bool start = true)
        {
            this.frames = frames != null ? frames : new int[1];
            this.spf = spf;
            time = 0;
            this.loop = loop;
            this.playing = start;
        }

        public void Update(float dt)
        {
            if (delayedStart > 0)
            {
                delayedStart -= dt;
                return;
            }
            if (!playing) return;

            time += dt;

            if (time >= spf)
            {
                index++;
                time = 0;

                if (index >= frames.Length)
                {
                    if (loop)
                        index = 0;
                    else
                        playing = false;
                }
            }
        }

        public void SetFrame(int[] frames)
        {
            this.frames = frames;
            index = Math.Min(index, frames.Length);
        }

        public int Frame()
        {
            return frames[index];
        }

        public bool IsFinished()
        {
            return loop == false && index >= frames.Length;
        }
    }
}