using UnityEngine;

namespace Discovery.Settings
{
    public class SetFov : MonoBehaviour
    {
        [SerializeField] private GameConfig config;

        public void SetValue(float value)
        {
            config.fov = value;
        }
    }   
}