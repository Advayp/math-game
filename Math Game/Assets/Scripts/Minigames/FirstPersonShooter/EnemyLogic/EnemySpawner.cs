using System.Collections;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.EnemyLogic
{
    public class EnemySpawner : MonoBehaviour, IEnableable
    {
        [SerializeField] private Transform[] spawnLocations;
        [SerializeField] private float spawnCooldown;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform target;
        
        [SerializeField] private bool doesDamage;
       

        private WaitForSeconds _spawnWaitForSeconds;
        private bool _isSpawning = true;
        private EnemyFactory _factory;

        private void Start()
        {
            _factory = new EnemyFactory(target, doesDamage, enemyPrefab);
            _spawnWaitForSeconds = new WaitForSeconds(spawnCooldown);
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (_isSpawning)
            {
                yield return _spawnWaitForSeconds;
                var desiredLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
                var enemy = _factory.Create(desiredLocation.position, Quaternion.identity);
                _factory.Process(enemy);
            }
        }


        #region Editor

        public void Spawn()
        {
            var enemy = Instantiate(enemyPrefab, spawnLocations[Random.Range(0, spawnLocations.Length)].position,
                Quaternion.identity);
            _factory.Process(enemy);
        }

        #endregion

        public void Enable()
        {
            _isSpawning = true;
        }

        public void Disable()
        {
            _isSpawning = false;
        }
    }
}