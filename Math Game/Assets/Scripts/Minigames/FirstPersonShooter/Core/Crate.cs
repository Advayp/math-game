using System;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class Crate : MonoBehaviour, IDamageable
    {
        [SerializeField, Range(50, 100)] private int maxHealth;

        public event Action<int> Shot;

        private int _health;

        private void Start()
        {
            _health = maxHealth;
            Shot += Damage;
        }

        public void TakeDamage(int amount)
        {
            Shot?.Invoke(amount);
        }

        private void Damage(int amount)
        {
            _health -= amount;
            if (_health > 0) return;
            Destroy(gameObject);
        }
    }
}