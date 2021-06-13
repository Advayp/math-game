using System;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField, Range(150, 200)] private int maxHealth;

        public static event Action OnDeath;

        private int _health;

        private void Start()
        {
            _health = maxHealth;
        }


        public void TakeDamage(int amount)
        {
            _health -= amount;
            if (_health > 0) return;
            HandleDeath();
        }

        private void HandleDeath()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}