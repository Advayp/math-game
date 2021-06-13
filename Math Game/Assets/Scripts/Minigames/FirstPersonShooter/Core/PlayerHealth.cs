using System;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class PlayerHealth : MonoBehaviour, IDamageable, IHealable
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private GameObject[] thingsToDisableOnDeath;


        public event Action<int> HealthChanged;
        public event Action Death;

        private int _currentHealth;

        public int MaxHealth => maxHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            HealthChanged?.Invoke(_currentHealth);
            if (_currentHealth <= 0)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            Death?.Invoke();
            foreach (var thingToDisable in thingsToDisableOnDeath)
            {
                var disables = thingToDisable.GetComponents<IEnableable>();

                foreach (var enableable in disables)
                {
                    enableable.Disable();
                }
            }
        }

        public void HealFor(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
            HealthChanged?.Invoke(+_currentHealth);
        }
    }
}