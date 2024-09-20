using System;
using UnityEngine;

namespace Sound
{
    [Serializable]
    public class BaseSound
    {
        public SoundsTypes Type;
        public AudioClip Clip;
        [Range(0f, 1f)] public float Volume; 
        [Range(.1f, 5f)] public float Pitch;
        public bool IsLooped;
        public AudioSource Source;
    }
}