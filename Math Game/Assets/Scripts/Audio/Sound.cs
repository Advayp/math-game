using System;
using UnityEngine;

namespace Discovery.Audio
{
    [Serializable]
    public enum AvailableSounds
    {
        Hover
    }
    
    [Serializable]
    public class Sound
    {
        public AvailableSounds type;
        
        public AudioClip clip;
       
        [Range(0, 1)]
        public float volume;
       
        [Range(0.1f, 3f)]
        public float pitch;

        [HideInInspector]
        public AudioSource source;
    }
}