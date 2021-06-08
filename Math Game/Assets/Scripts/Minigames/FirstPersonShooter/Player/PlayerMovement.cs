using System;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour, IEnableable
    {
        [SerializeField] private float moveSpeed, maxSpeed;
        [SerializeField] private string groundTag = "Ground";
        
        
        private Vector2 _inputDirection;
        private Rigidbody _rigidbody;
        private IPlayerInput _playerInput;
        private bool _isEnabled = true;
        private bool _isGrounded = true;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerInput = GetComponent<IPlayerInput>();
        }

        private void Update()
        {
            if (_isEnabled == false) return;
            if (_rigidbody.velocity.magnitude > maxSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
            }

            _inputDirection = _playerInput.GetInput();

            _rigidbody.AddForce(transform.forward * (_inputDirection.y * moveSpeed * Time.deltaTime));
            _rigidbody.AddForce(transform.right * (_inputDirection.x * moveSpeed * Time.deltaTime));
            
            if (_playerInput.GetJump() && _isGrounded) Jump();
        }

        private void Jump()
        {
            _rigidbody.AddForce(transform.up * 500);
            _isGrounded = false;
        }

        public void Enable() => _isEnabled = true;

        public void Disable() => _isEnabled = false;

        private void OnCollisionEnter(Collision other)
        {
            print(other.gameObject.name.Bold().Color(AvailableColors.Green));
            
            if (other.collider.CompareTag(groundTag))
            {
                _isGrounded = true;
            }
        }
    }
}
