using System;
using System.Collections;
using MathGame.Minigames.FirstPersonShooter.Core;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform mainCamera;

        [Header("Gun Variables"), SerializeField]
        private int maxDistance;

        [SerializeField, Range(2, 10)] private int damage;
        [SerializeField, Range(10, 15)] private float fireRate;
        [SerializeField] private int maxAmmo;
        [SerializeField] private float reloadDuration;

        public event Action<Vector3, Vector3> Shot;

        private float _nextTimeToFire;
        private IGunInput _gunInput;
        private IAmmoManager _ammoManager;

        private void Awake()
        {
            _gunInput = GetComponent<IGunInput>();
            _ammoManager = new AmmoManager(maxAmmo);
        }

        private void Update()
        {
            if (!_gunInput.GetInput() || !(Time.time >= _nextTimeToFire)) return;
            if (_ammoManager.UseBullet())
            {
                _nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
            else if (_ammoManager.IsReloading == false)
            {
                StartCoroutine(ReloadCoroutine());
            }
        }

        private IEnumerator ReloadCoroutine()
        {
            _ammoManager.StartReloading();
            Debug.Log("Need To Reload");
            yield return new WaitForSeconds(reloadDuration);
            _ammoManager.StopReloading();
            Debug.Log("Reloaded");
        }

        private void Shoot()
        {
            if (!Physics.Raycast(mainCamera.position, mainCamera.forward, out var hit, maxDistance)) return;
            var damageable = hit.collider.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
            Shot?.Invoke(hit.point, hit.normal);
        }
    }
}