using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.EnemyLogic
{
    public class EnemyFactory
    {
        private readonly Transform _target;
        private readonly bool _doesDamage;
        private readonly GameObject _enemyPrefab;

        public EnemyFactory(Transform target, bool doesDamage, GameObject enemyPrefab)
        {
            _target = target;
            _doesDamage = doesDamage;
            _enemyPrefab = enemyPrefab;
        }

        public void Process(GameObject enemyToConfigure)
        {
            var enemy = enemyToConfigure.GetComponent<Enemy>();
            var enemyAttack = enemyToConfigure.GetComponent<IEnemyAttack>();

            enemy.target = _target;
            enemyAttack.DoesDamage = _doesDamage;
            enemyAttack.Target = _target;
        }

        public GameObject Create(Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(_enemyPrefab, position, rotation);
        }
    }
}