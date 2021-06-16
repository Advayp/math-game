using System.Collections;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.EnemyLogic
{
    public class EnemyShoot : MonoBehaviour, IEnemyAttack
    {
        [SerializeField, Tooltip("The Enemy script attached to this gameObject")]
        private Enemy mainEnemy;

        [SerializeField] private Transform gunTip;
        [SerializeField] private Transform gun;
        [SerializeField] private int damageDealt = 5;

        [SerializeField] private float timeBetweenFire;
        [SerializeField] private Bullet bulletPrefab;


        private bool _doesDamage;
        private WaitForSeconds _cooldown;

        public bool DoesDamage
        {
            set => _doesDamage = value;
        }

        public Transform Target { get; set; }

        private void Awake()
        {
            Target = GetComponent<Enemy>().target;

            _cooldown = new WaitForSeconds(timeBetweenFire);
        }

        private void Start()
        {
            StartCoroutine(AttackCoroutine());
        }


        private void FixedUpdate()
        {
            if (!mainEnemy.IsEnabled) return;
            var desiredRotation = Quaternion.LookRotation(Target.position - gun.position);
            desiredRotation.x = Mathf.Clamp(desiredRotation.x, -90, 90);
            gun.transform.rotation = desiredRotation;
        }

        private IEnumerator AttackCoroutine()
        {
            if (_doesDamage == false) yield break;
            while (true)
            {
                Shoot();
                yield return _cooldown;
            }
        }

        private void Shoot()
        {
            bulletPrefab.Initialize(damageDealt);
            Instantiate(bulletPrefab.gameObject, gunTip.position, gun.rotation);
        }
    }
}