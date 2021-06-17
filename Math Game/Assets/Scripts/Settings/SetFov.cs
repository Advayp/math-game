using UnityEngine;

namespace Discovery.Settings
{
    public class SetFov : MonoBehaviour
    {
        [SerializeField] private FPSGameConfig config;

        public void SetValue(float value)
        {
            config.fov = value;
        }
    }   
}