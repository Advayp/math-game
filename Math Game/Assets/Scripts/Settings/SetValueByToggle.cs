using UnityEngine;

namespace Discovery.Settings
{
    public class SetValueByToggle : MonoBehaviour
    {
        [SerializeField] private FPSGameConfig config;
        [SerializeField] private Fields field;

        public void SetValue(bool value)
        {
            config.Set(field, value);
        }
    }
}