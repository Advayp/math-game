using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.EnemyLogic
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int damageToPlayer;
        [SerializeField] private string playerTag = "Player";
        [SerializeField] private bool doesDamage;

        public bool DoesDamage
        {
            get => doesDamage;
            set => doesDamage = value;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (doesDamage == false) return;
            if (other.gameObject.CompareTag(playerTag) == false) return;
            var damageable = other.gameObject.GetComponent<IDamageable>();
            damageable.TakeDamage(damageToPlayer);
        }
    }
}