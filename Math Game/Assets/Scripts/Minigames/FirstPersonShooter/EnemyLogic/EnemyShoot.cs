using System.Collections;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.EnemyLogic
{
    public class EnemyShoot : MonoBehaviour, IEnemyAttack
    {
        [SerializeField] private Transform gunTip;
        [SerializeField] private Transform gun;
        [SerializeField] private int damageDealt = 5;
        
        [SerializeField] private float timeBetweenFire;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float destroyTime = 4f;


        private bool _doesDamage;
        private WaitForSeconds _coolDown;

        public bool DoesDamage
        {
            set => _doesDamage = value;
        }

        public Transform Target { get; set; }

        private void Awake()
        {
            Target = GetComponent<Enemy>().target;

            _coolDown = new WaitForSeconds(timeBetweenFire);
        }

        private void Start()
        {
            StartCoroutine(AttackCoroutine());
        }


        private void Update()
        {
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
                yield return _coolDown;
            }
        }

        private void Shoot()
        {
            bulletPrefab.Initialize(damageDealt);
            var bullet = Instantiate(bulletPrefab.gameObject, gunTip.position, gun.rotation);
            Destroy(bullet, destroyTime);
        }
    }
}