using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour, IEnableable
    {
        [SerializeField, Header("Movement Variables")]
        private float moveSpeed;

        [SerializeField] private float maxSpeed;

        [SerializeField, Header("Jump Variables")]
        private float jumpForce = 400;

        [SerializeField, Tooltip("The Amount to divide the moveSpeed by when jumping")]
        private float speedMultiplierWhenJumping;


        [SerializeField] private string groundTag = "Ground";


        private Vector2 _inputDirection;
        private Rigidbody _rigidbody;
        private IPlayerInput _playerInput;
        private bool _isEnabled = true;
        private bool _isGrounded = true;
        private float _currentMoveSpeed, _moveSpeedWhenJumping;
        private Vector3 _previousVel;
        private CapsuleCollider _collider;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerInput = GetComponent<IPlayerInput>();
            _collider = GetComponent<CapsuleCollider>();
        }

        private void Start()
        {
            _moveSpeedWhenJumping = moveSpeed / speedMultiplierWhenJumping;
            _currentMoveSpeed = moveSpeed;
            
            Debug.Log("<color=#26ed7c>1234</color>");
        }

        private void Update()
        {
            if (_isEnabled == false) return;

            _currentMoveSpeed = _isGrounded ? moveSpeed : _moveSpeedWhenJumping;

            if (_rigidbody.velocity.magnitude > maxSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
            }

            _inputDirection = _playerInput.GetInput();

            _rigidbody.AddForce(transform.forward * (_inputDirection.y * _currentMoveSpeed * Time.deltaTime));
            _rigidbody.AddForce(transform.right * (_inputDirection.x * _currentMoveSpeed * Time.deltaTime));

            if (_playerInput.GetJump() && _isGrounded) Jump();
        }

        private void Jump()
        {
            _rigidbody.AddForce(transform.up * jumpForce);
            _isGrounded = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag(groundTag))
            {
                _isGrounded = true;
            }
        }

        private void PauseRigidbody()
        {
            _collider.enabled = false;
            _previousVel = _rigidbody.velocity;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.useGravity = false;
        }

        private void UnpauseRigidbody()
        {
            _collider.enabled = true;
            _rigidbody.velocity = _previousVel;
            _rigidbody.useGravity = true;
        }

        public void Enable()
        {
            UnpauseRigidbody();

            _isEnabled = true;
        }

        public void Disable()
        {
            PauseRigidbody();

            _isEnabled = false;
        }
    }
}