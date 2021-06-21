using Discovery.Minigames.FirstPersonShooter.InputHandlers;
using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour, IEnableable
    {
        [SerializeField, Header("Movement Variables")]
        protected float moveSpeed;

        [SerializeField] protected float maxSpeed;

        [SerializeField, Header("Jump Variables")]
        private float jumpForce = 400;

        [SerializeField] protected int maxJumps = 1;
        

        [SerializeField, Tooltip("The Amount to divide the moveSpeed by when jumping")]
        protected float speedMultiplierWhenJumping;


        [SerializeField] private string groundTag = "Ground";


        // Input
        private Vector2 _inputDirection;
        private IPlayerInput _playerInput;
        
        // Moving
        private Rigidbody _rigidbody;
        private float _currentMoveSpeed;
        private float _moveSpeedWhenJumping;

        // Pausing
        private Vector3 _previousVel;
        private CapsuleCollider _collider;
        private bool _isEnabled = true;

        // Jumping
        protected int CurrentNumberOfJumps { get; set; }

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

            CurrentNumberOfJumps = maxJumps;
        }

        protected virtual void Update()
        {
            if (_isEnabled == false) return;

            _currentMoveSpeed = CurrentNumberOfJumps > 0 ? moveSpeed : _moveSpeedWhenJumping;

            if (_rigidbody.velocity.magnitude > maxSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
            }

            _inputDirection = _playerInput.GetInput();

            _rigidbody.AddForce(transform.forward * (_inputDirection.y * _currentMoveSpeed * Time.deltaTime));
            _rigidbody.AddForce(transform.right * (_inputDirection.x * _currentMoveSpeed * Time.deltaTime));

            if (_playerInput.GetJump() && CurrentNumberOfJumps > 0) Jump();
        }

        private void Jump()
        {
            CurrentNumberOfJumps--;
            _rigidbody.AddForce(transform.up * jumpForce);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag(groundTag))
            {
                CurrentNumberOfJumps = maxJumps;
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

        protected void RecalculateMoveSpeed()
        {
            _moveSpeedWhenJumping = moveSpeed / speedMultiplierWhenJumping;
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