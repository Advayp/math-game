using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Discovery.Minigames.FirstPersonShooter.PowerUps
{
    public class FpsPowerUpSpawner : MonoBehaviour, IEnableable
    {
        #region Inspector Variables

        [SerializeField] private Transform[] spawnLocations;
        [SerializeField] private float spawnDelay;
        [SerializeField] private GameObject[] powerUps;
        [SerializeField] private float destroyDelay;
        [SerializeField] private int maxPowerUpCount;

        #endregion


        private bool _isSpawning = true;
        private WaitForSeconds _spawnDelay;
        private IEnumerator _currentWave;
        private int _numberOfActivePowerUps;

        private bool CanSpawn => _numberOfActivePowerUps < maxPowerUpCount;

        private void Awake()
        {
            powerUps.RequireComponent<FpsPowerUp>(this);
        }

        private void Start()
        {
            _spawnDelay = new WaitForSeconds(spawnDelay);
            _numberOfActivePowerUps = 0;
        }

        private void Update()
        {
            if (!_isSpawning || _currentWave != null)
                return;
            StartNewWave();
        }

        private void StartNewWave()
        {
            _currentWave = SpawnCoroutine();
            StartCoroutine(_currentWave);
        }

        private IEnumerator SpawnCoroutine()
        {
            if (CanSpawn == false)
            {
                _currentWave = null;
                yield break;
            }
            yield return _spawnDelay;
            var index = Random.Range(0, spawnLocations.Length);
            var indexOfPowerUp = Random.Range(0, powerUps.Length);
            var chosenLocation = spawnLocations[index];
            var chosenPowerUp = powerUps[indexOfPowerUp];

            var powerUp = Instantiate(chosenPowerUp, chosenLocation.localPosition, Quaternion.identity);
            
            _numberOfActivePowerUps++;
            StartCoroutine(DestroyCoroutine(powerUp, destroyDelay));

            _currentWave = null;
        }

        // I made this method myself because I want to keep
        // track of the number of active power ups
        private IEnumerator DestroyCoroutine(Object objectToDestroy, float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(objectToDestroy);
            _numberOfActivePowerUps--;
        }

        public void Enable() => _isSpawning = true;

        public void Disable() => _isSpawning = false;
    }
}