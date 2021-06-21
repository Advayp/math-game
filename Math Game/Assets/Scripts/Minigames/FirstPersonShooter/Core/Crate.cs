using System;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class Crate : MonoBehaviour, IDamageable
    {
        [SerializeField, Range(50, 100)] private int maxHealth;

        public event Action<float> Shot;

        private float _health;

        private void Start()
        {
            _health = maxHealth;
            Shot += Damage;
        }

        public void TakeDamage(float amount)
        {
            Shot?.Invoke(amount);
        }

        private void Damage(float amount)
        {
            _health -= amount;
            if (_health > 0) return;
            Destroy(gameObject);
        }
    }
}