using System;

namespace UltraLight
{
    public class Animation
    {
        public bool loop = false;
        public int[] frames;
        public int index;
        public float spf;
        public float time;
        public bool start;

        public Animation(int[] frames, bool loop = true, float spf = 0.2f, bool start = true)
        {
            this.frames = frames != null ? frames : new int[1];
            this.spf = spf;
            time = 0;
            this.loop = loop;
            this.start = start;
        }

        public void Update(float dt)
        {
            if (!start) return;

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
                        index = frames.Length - 1;
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
            return loop == false && index == frames.Length - 1;
        }
    }
}