using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.EnemyLogic
{
    public class EnemyHitAttack : MonoBehaviour, IEnemyAttack
    {
        [SerializeField] private int damageToPlayer;
        [SerializeField] private bool doesDamage;
        

        public bool DoesDamage
        {
            set => doesDamage = value;
        }

        public Transform Target { get; set; }


        private void OnCollisionEnter(Collision other)
        {
            if (doesDamage == false) return;
            if (other.gameObject.CompareTag(Target.gameObject.tag) == false) return;
            var damageable = other.gameObject.GetComponent<IDamageable>();
            damageable.TakeDamage(damageToPlayer);
        }
    }
}