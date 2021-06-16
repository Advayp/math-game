using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Discovery.Minigames.FirstPersonShooter.EnemyLogic
{
    public class EnemySpawner : MonoBehaviour, IEnableable
    {
        [SerializeField, Header("Dependencies"), Space] private Transform target;
        
        [SerializeField, Header("Config"), Space] private Transform[] spawnLocations;
        [SerializeField] private float spawnCooldown;
        [SerializeField] private GameObject enemyPrefab;

        [SerializeField] private bool doesDamage;


        private WaitForSeconds _spawnWaitForSeconds;
        private bool _isSpawning = true;
        private EnemyFactory _factory;
        private IEnumerator _currentSpawnWave;


        private void Start()
        {
            _factory = new EnemyFactory(target, doesDamage, enemyPrefab);
            _spawnWaitForSeconds = new WaitForSeconds(spawnCooldown);
            StartCoroutine(SpawnCoroutine());
        }

        private void Update()
        {
            if (!_isSpawning || _currentSpawnWave != null) return;
            _currentSpawnWave = SpawnCoroutine();
            StartCoroutine(_currentSpawnWave);
        }

        private IEnumerator SpawnCoroutine()
        {
            yield return _spawnWaitForSeconds;
            var desiredLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
            var enemy = _factory.Create(desiredLocation.position, Quaternion.identity);
            _factory.Process(enemy);
            _currentSpawnWave = null;
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
            if (_currentSpawnWave != null)
            {
                StopCoroutine(_currentSpawnWave);
                _currentSpawnWave = null;
            }

            _isSpawning = false;
        }
    }
}