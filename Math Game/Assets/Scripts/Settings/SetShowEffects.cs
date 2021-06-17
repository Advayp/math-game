using UnityEngine;

namespace Discovery.Settings
{
    public class SetShowEffects : MonoBehaviour
    {
        [SerializeField] private FPSGameConfig config;

        public void SetValue(bool value)
        {
            config.showEffects = value;
        }
    }
}