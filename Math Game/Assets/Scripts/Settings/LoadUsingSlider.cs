using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Settings
{
    public class LoadUsingSlider : MonoBehaviour
    {
        [SerializeField] private FPSGameConfig config;
        [SerializeField] private Slider slider;
        [SerializeField] private Fields field;

        private void Start()
        {
            slider.value = (float)config.Get(field);
        }
    }
}