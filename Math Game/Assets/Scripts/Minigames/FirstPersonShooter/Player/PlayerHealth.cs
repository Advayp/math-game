using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private GameObject[] thingsToDisableOnDeath;
        

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
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            Log("Player Died");
            foreach (var thingToDisable in thingsToDisableOnDeath)
            {
                var disable = thingToDisable.GetComponent<IEnableable>();
                disable.Disable();
            }
        }

        private static void Log(string message) => Debug.Log(message);
    }
}