using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private string playerTag;
        [SerializeField] private int damageDealt;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(transform.forward * (moveSpeed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag(playerTag))
            {
                Destroy(gameObject);
                return;
            }

            var damageable = other.gameObject.GetComponent<IDamageable>();
            damageable.TakeDamage(damageDealt);
        }

        public void Initialize(int damage)
        {
            damageDealt = damage;
        }
    }
}