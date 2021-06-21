using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery.Settings
{
    public class SetValueBySlider : MonoBehaviour
    {
        [FormerlySerializedAs("field")] [SerializeField] private Field field;
        [SerializeField] private GameConfig config;

        public void SetValue(float value)
        {
            config.Set(field, value);
        }
    }
}