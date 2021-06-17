using UnityEngine;

namespace Discovery
{
    [CreateAssetMenu]
    public class FPSGameConfig : ScriptableObject
    {
        public const string MouseSenseString = nameof(mouseSensitivity);
        public const string FovString = nameof(fov);
        public const string ShowEffectsString = nameof(showEffects);
        
        [Range(100, 250), Header("Mouse Variables")]
        public float mouseSensitivity;

        [Range(30, 100)]
        public float fov;

        [Header("Effects")]
        public bool showEffects;

    }
}