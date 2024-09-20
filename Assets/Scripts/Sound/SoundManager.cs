using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        public List<BaseSound> Sounds;

        public static SoundManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(gameObject);
            
            foreach (var sound in Sounds)
            {
                SetupSourceWithSoundData(sound);
            }
        }
        
        public void Play(SoundsTypes type)
        {
            var sound = Sounds.Find(item => item.Type == type);

            if (sound == null)
            {
                Debug.LogWarning($"Sound with type: {type} isn't found!");
                return;
            }
            
            sound.Source.PlayOneShot(sound.Clip);
        }

        public void Reset()
        {
            foreach (var sound in Sounds.Where(sound => sound.Source.isPlaying))
            {
                sound.Source.Stop();
            }
        }

        private void SetupSourceWithSoundData(BaseSound sound)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();

            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.IsLooped;
        }
    }
}