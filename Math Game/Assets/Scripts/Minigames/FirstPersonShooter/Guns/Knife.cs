using System;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    [RequireComponent(typeof(Animator))]
    public class Knife : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space] private AnimationClip attackClip;
        [SerializeField, Header("Config"), Space] private float damageDealt;
        

        private IGunInput _input;
        private Animator _animator;
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

        private void Awake()
        {
            _input = GetComponent<IGunInput>();
            _animator = GetComponent<Animator>();
            attackClip.Require(this);
        }

        private void Update()
        {
            if (_input.GetInput() && _animator.GetBool(IsAttacking) == false)
            {
                Attack();
            }
        }

        private void Attack()
        {
            _animator.SetBool(IsAttacking, true);
            Invoke(nameof(StopAttacking), attackClip.length);
        }

        private void StopAttacking()
        {
            _animator.SetBool(IsAttacking, false);
        }

        private void OnCollisionEnter(Collision other)
        {
           print($"Collided with {other.gameObject.name}"); 
        }
    }
}