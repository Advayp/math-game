using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Minigames.FirstPersonShooter.UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField, Tooltip("The Player whose health to track")]
        private PlayerHealth player;

        private Slider _slider;


        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            player.HealthChanged += UpdateValue;
        }

        private void Start()
        {
            _slider.maxValue = player.MaxHealth;
            _slider.minValue = 0;
            _slider.value = player.MaxHealth;
        }

        private void OnDisable()
        {
            player.HealthChanged -= UpdateValue;
        }

        private void UpdateValue(int newHealth)
        {
            _slider.value = newHealth;
        }
    }
}