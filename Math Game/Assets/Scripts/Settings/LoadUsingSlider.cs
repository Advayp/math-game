using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Discovery.Settings
{
    public class LoadUsingSlider : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private Slider slider;
        [FormerlySerializedAs("field")] [SerializeField] private Field field;

        private void Start()
        {
            slider.value = (float)config.Get(field);
        }
    }
}