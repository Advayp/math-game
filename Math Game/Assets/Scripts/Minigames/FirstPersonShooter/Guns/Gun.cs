using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public class Gun : MonoBehaviour, IEnableable
    {
        [SerializeField] private Transform mainCamera;
        [SerializeField] private GameObject ammoCounter;

        [SerializeField] private AnimationClip reloadAnimation;

        [FormerlySerializedAs("maxDistance")] [Header("Gun Variables"), SerializeField]
        private int shootingDistance;

        [SerializeField, Range(2, 50)] private int damage;
        [SerializeField, Range(10, 150)] private float fireRate;
        [SerializeField] private int maxAmmo;

        public event Action<Vector3, Vector3> Shot;

        private float _nextTimeToFire;
        private IGunInput _gunInput;
        private IAmmoManager _ammoManager;
        private IAmmoDisplayer _ammoDisplayer;
        private WaitForSeconds _reloadWaitForSeconds;
        private IGunEffect _gunEffects;
        private IReloadTimeCalculator _reloadTimeCalculator;
        private bool _isEnabled = true;

        private void Awake()
        {
            _gunInput = GetComponent<IGunInput>();
            _ammoDisplayer = ammoCounter.GetComponent<IAmmoDisplayer>();
            _reloadTimeCalculator = new MultipleOfTenReloadTimeCalculator();
            _reloadWaitForSeconds = new WaitForSeconds(reloadAnimation.length * _reloadTimeCalculator.Calculate(maxAmmo));
            _gunEffects = GetComponent<IGunEffect>();
        }

        private void Start()
        {
            _ammoManager = new AmmoManager(maxAmmo);
            UpdateAmmoCount();
        }

        private void Update()
        {
            if (_isEnabled == false) return;
            if (Input.GetKey(KeyCode.R) && _ammoManager.NeedsToReload)
            {
                StartCoroutine(ReloadCoroutine());
            }
            if (!_gunInput.GetInput() || !(Time.time >= _nextTimeToFire)) return;
            if (_ammoManager.UseBullet() && _ammoManager.IsReloading == false)
            {
                Shoot();
            }
            else if (_ammoManager.IsReloading == false)
            {
                StartCoroutine(ReloadCoroutine());
            }
        }

        private IEnumerator ReloadCoroutine()
        {
            _gunEffects.OnReloadStart();
            _ammoManager.StartReloading();
            yield return _reloadWaitForSeconds;
            _ammoManager.StopReloading();
            _gunEffects.OnReloadStop();
            
            
            UpdateAmmoCount();
        }

        [ContextMenu("Stop Reloading")]
        private void StopReloadAnimation() => _gunEffects.OnReloadStop(); 

        [ContextMenu("Start Reloading")]
        private void StartReloadAnimation() => _gunEffects.OnReloadStart(); 

        private void Shoot()
        {
            _gunEffects.OnShoot();
            _nextTimeToFire = Time.time + 1f / fireRate;
            
            UpdateAmmoCount();
            
            if (!Physics.Raycast(mainCamera.position, mainCamera.forward, out var hit, shootingDistance)) return;
            var damageable = hit.collider.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
            Shot?.Invoke(hit.point, hit.normal);
        }

        private void UpdateAmmoCount()
        {
            _ammoDisplayer.UpdateText(_ammoManager.CurrentAmmoCount);
        }

        public void Enable()
        {
            _isEnabled = true;      
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}