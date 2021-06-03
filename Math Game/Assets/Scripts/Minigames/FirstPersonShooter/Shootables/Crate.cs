using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Shootables
{
    public class Crate : MonoBehaviour, IDamageable
    {
        [SerializeField, Range(50, 100)] private int maxHealth;
        
        private int _health;

        private void Start()
        {
            _health = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _health -= amount;
            Log("Crate has been hit!");
            if (_health > 0) return;
            Destroy(gameObject); 
        }

        private void Log(string message)
        {
            Debug.Log(message, this);
        }
    }
}