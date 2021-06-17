using UnityEngine;

namespace Discovery.Settings
{
    public class SetMouseSensitivity : MonoBehaviour
    {
        [SerializeField] private FPSGameConfig config;

        public void SetValue(float value)
        {
            config.mouseSensitivity = value;
        }
    }
}