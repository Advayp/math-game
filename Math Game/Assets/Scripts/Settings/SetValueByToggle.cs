using UnityEngine;

namespace Discovery.Settings
{
    public class SetValueByToggle : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private Field field;

        public void SetValue(bool value)
        {
            config.Set(field, value);
        }
    }
}