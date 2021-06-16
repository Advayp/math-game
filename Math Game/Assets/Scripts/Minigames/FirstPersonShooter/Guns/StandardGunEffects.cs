using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    [RequireComponent(typeof(Animator))]
    public class StandardGunEffects : MonoBehaviour, IGunEffect
    {
        [SerializeField] private ParticleSystem muzzleFlash;

        private Animator _animator;
        private static readonly int IsReloading = Animator.StringToHash("IsReloading");
        private Quaternion _originalRotation;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _originalRotation = transform.rotation;
        }

        public void OnReloadStart()
        {
            _animator.SetBool(IsReloading, true);
        }

        public void OnReloadStop()
        {
            _animator.SetBool(IsReloading, false);
            transform.rotation = _originalRotation;
        }

        public void OnShoot()
        {
            muzzleFlash.Play();
        }
        
    }
}