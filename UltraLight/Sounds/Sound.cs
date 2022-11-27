using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
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

            soundEffectInstances = new Dictionary<string, List<SoundEffectInstance>>();

            foreach (var sfx in soundEffects)
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

        public void PlaySound(string pKey, bool pAllowInterrupt = false)
        {
            if (soundEffectInstances.ContainsKey(pKey))
            {
                var instances = soundEffectInstances[pKey];
                var instancesStopped = instances.Where(s => s.State == SoundState.Stopped);

                if (instancesStopped.Count() == 0 && pAllowInterrupt)
                {
                    var instance = instances.First();
                    instance.Stop();
                    instance.Play();
                }
                else if (instancesStopped.Count() > 0)
                {
                    instancesStopped.First().Play();
                }
            }
        }

        public void StopSound(string pKey)
        {
            if (soundEffectInstances.ContainsKey(pKey))
            {
                var instances = soundEffectInstances[pKey];
                foreach (var instance in instances)
                {
                    if (instance.State != SoundState.Stopped)
                    {
                        instance.Stop();
                    }
                }
            }
        }

        public SoundEffect LoadSoundEffect(string name)
        {
            return Game1.myContent.Load<SoundEffect>(name);
        }
    }
}