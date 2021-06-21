using UnityEngine;

namespace Discovery.Settings
{
    public class SetMouseSensitivity : MonoBehaviour
    {
        [SerializeField] private GameConfig config;

        public void SetValue(float value)
        {
            config.mouseSensitivity = value;
        }
    }
}