using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;

        private int _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }


        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}