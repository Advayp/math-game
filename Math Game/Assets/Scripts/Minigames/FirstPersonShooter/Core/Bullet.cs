using System.Collections;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
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
            StartCoroutine(DeathCoroutine());
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(transform.forward * (moveSpeed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision other)
        {
            var damageable = other.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(damageDealt);
            
            Destroy(gameObject);

        }
        private IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }

        public void Initialize(int damage)
        {
            damageDealt = damage;
        }

    }
}