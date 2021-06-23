using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public class StandardChargeUpDisplayer : MonoBehaviour, IChargeAmountDisplayer
    {
        [SerializeField] private Slider slider;

        private float _maxValue;

        public void Initialize(float maxValue)
        {
            _maxValue = maxValue;
            slider.minValue = 0;
            slider.maxValue = _maxValue;
        }


        public void HandleTime(float currentValue)
        {
            slider.value = currentValue;
        }

        public void Hide()
        {
           slider.gameObject.SetActive(false); 
        }

        public void Show()
        {
           slider.gameObject.SetActive(true); 
        }
    }
}