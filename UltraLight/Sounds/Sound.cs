using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UltraLight.Sounds
{
    public class Sound
    {
        private Dictionary<string, SoundFX> settings;
        private Dictionary<string, SoundEffect> soundEffects;
        private Dictionary<string, List<SoundEffectInstance>> soundEffectInstances;
        private int maxSoundEffects = 3;

        public Sound(List<SoundFX> settings)
        {
            this.settings = settings.ToDictionary(s => s.Key);
            LoadContent();
        }

        private void LoadContent()
        {
            soundEffects = new Dictionary<string, SoundEffect>();
            soundEffectInstances = new Dictionary<string, List<SoundEffectInstance>>();

            foreach (var sfx in settings)
            {
                SoundEffect soundEffect = LoadSoundEffect(sfx.Value.Filename);

                if (soundEffect != null)
                {
                    soundEffects.Add(sfx.Key, soundEffect);
                }
            }

            foreach(var sfx in soundEffects)
            {
                List<SoundEffectInstance> sfxInstances = new List<SoundEffectInstance>();

                for (int i = 0; i < maxSoundEffects; i++)
                {
                    SoundEffectInstance sfxInstance = sfx.Value.CreateInstance();
                    sfxInstance.Volume = settings[sfx.Key].DefaultVolume;
                    sfxInstance.Pitch = settings[sfx.Key].DefaultPitch;
                    sfxInstances.Add(sfxInstance);
                }

                soundEffectInstances.Add(sfx.Key, sfxInstances);
            }
        }

        public SoundEffect LoadSoundEffect(string name)
        {
            SoundEffect sfx;

            if (File.Exists(name))
            {
                using (var stream = File.OpenRead(name))
                {
                    sfx = SoundEffect.FromStream(stream);
                }
            }
            else
            {
                throw new FileNotFoundException("Cound not find file: " + name);
            }

            return sfx;
        }
    }
}
