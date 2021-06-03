using System;
using System.Collections;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform mainCamera;
        [SerializeField] private GameObject ammoCounter;
        
        [SerializeField, Header("Effects")] private Animator animator;
        [SerializeField] private AnimationClip reloadAnimation;
        [SerializeField] private ParticleSystem muzzleFlash;

        [Header("Gun Variables"), SerializeField]
        private int maxDistance;

        [SerializeField, Range(2, 10)] private int damage;
        [SerializeField, Range(10, 15)] private float fireRate;
        [SerializeField] private int maxAmmo;

        public event Action<Vector3, Vector3> Shot;

        private float _nextTimeToFire;
        private IGunInput _gunInput;
        private IAmmoManager _ammoManager;
        private IAmmoDisplayer _ammoDisplayer;
        private WaitForSeconds _reloadWaitForSeconds;


        private static readonly int IsReloading = Animator.StringToHash("IsReloading");

        private void Awake()
        {
            _gunInput = GetComponent<IGunInput>();
            _ammoDisplayer = ammoCounter.GetComponent<IAmmoDisplayer>();
            _reloadWaitForSeconds = new WaitForSeconds(reloadAnimation.length);
        }

        private void Start()
        {
            _ammoManager = new AmmoManager(maxAmmo);
            UpdateAmmoCount();
        }

        private void Update()
        {
            if (!_gunInput.GetInput() || !(Time.time >= _nextTimeToFire)) return;
            if (_ammoManager.UseBullet())
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
            StartReloadAnimation();
            _ammoManager.StartReloading();
            yield return _reloadWaitForSeconds;
            StopReloadAnimation();
            _ammoManager.StopReloading();

            UpdateAmmoCount();
        }

        [ContextMenu("Stop Reloading")]
        private void StopReloadAnimation() => animator.SetBool(IsReloading, false);

        [ContextMenu("Start Reloading")]
        private void StartReloadAnimation() => animator.SetBool(IsReloading, true);

        private void Shoot()
        {
            muzzleFlash.Play();
            _nextTimeToFire = Time.time + 1f / fireRate;
            
            UpdateAmmoCount();
            
            if (!Physics.Raycast(mainCamera.position, mainCamera.forward, out var hit, maxDistance)) return;
            var damageable = hit.collider.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
            Shot?.Invoke(hit.point, hit.normal);
        }

        private void UpdateAmmoCount()
        {
            _ammoDisplayer.UpdateText(_ammoManager.CurrentAmmoCount);
        }
    }
}