using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour, IEnableable
    {
        [SerializeField] private float moveSpeed, maxSpeed;
        
        private Vector2 _inputDirection;
        private Rigidbody _rigidbody;
        private IPlayerInput _playerInput;
        private bool _isEnabled = true;

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
        }

        public void Enable() => _isEnabled = true;

        public void Disable() => _isEnabled = false;
    }
}
