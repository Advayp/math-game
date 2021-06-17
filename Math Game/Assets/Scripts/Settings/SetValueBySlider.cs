using UnityEngine;

namespace Discovery.Settings
{
    public class SetValueBySlider : MonoBehaviour
    {
        [SerializeField] private Fields field;
        [SerializeField] private FPSGameConfig config;

        public void SetValue(float value)
        {
            config.Set(field, value);
        }
    }
}