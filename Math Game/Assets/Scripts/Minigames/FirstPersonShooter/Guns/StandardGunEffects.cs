using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    [RequireComponent(typeof(Animator))]
    public class StandardGunEffects : MonoBehaviour, IGunEffect
    {
        [SerializeField] private ParticleSystem muzzleFlash;
        
        private Animator _animator;
        private static readonly int IsReloading = Animator.StringToHash("IsReloading");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnReloadStart()
        {
            _animator.SetBool(IsReloading, true);
        }

        public void OnReloadStop()
        {
            _animator.SetBool(IsReloading, false);
        }

        public void OnShoot()
        {
            muzzleFlash.Play();
        }
        
    }
}