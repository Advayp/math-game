using System;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter
{
    public class Crate : MonoBehaviour, IDamageable
    {
        [SerializeField, Range(50, 100)] private int maxHealth;

        public event Action<int> Shot;
        public event Action Death;
        
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
            Log("Crate has been hit");
            if (_health > 0) return;
            Death?.Invoke();
            Destroy(gameObject);
        }

        private void Log(string message)
        {
            Debug.Log(message, this);
        }
    }
}