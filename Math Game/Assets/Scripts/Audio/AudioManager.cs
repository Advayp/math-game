using System;
using UnityEngine;

namespace Discovery.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Sound[] sounds;

        public static AudioManager Instance;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            foreach (var sound in sounds)
            {
                InitializeSound(sound);
            }
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializeSound(Sound sound)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            
            sound.source.clip = sound.clip;
            
            sound.source.pitch = sound.pitch;
            sound.source.volume = sound.volume;
        }

        public void Play(AvailableSounds type)
        {
            var sound = Array.Find(sounds, e => e.type == type);

            sound?.source.Play();
        }
    }
}