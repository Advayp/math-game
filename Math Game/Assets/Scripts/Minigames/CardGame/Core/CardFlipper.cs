using UnityEngine;
using UnityEngine.Events;

namespace Discovery.Minigames.CardGame
{
    public class CardFlipper : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space] private CardSet set;
        
        
        [SerializeField, Header("Config"), Space]
        private Vector3 desiredPosition;
        [SerializeField, Range(0, 2)] private float smoothSpeed;
        [SerializeField, Range(0, 0.1f)] private float rotationSmoothSpeed;
        [SerializeField] private float positionThreshold;
        [SerializeField] private UnityEvent<Vector3> reachedPosition;
        

        private bool _canFlip;
        private Transform _transform;
        private Vector3 _originalPosition;

        private void Awake()
        {
            _transform = transform;
            set.Require(this);
            set.Add(this);
        }

        private void Start()
        {
            _originalPosition = _transform.position;
        }

        private void OnDestroy()
        {
           set.Remove(this); 
        }

        private void Update()
        {
            if (_canFlip == false) return;

            if ((_transform.position - desiredPosition).sqrMagnitude >= positionThreshold * positionThreshold)
            {
                Flip();
            }
            else
            {
                reachedPosition?.Invoke(transform.position);
                Destroy(gameObject);
            }
        }

        private void Flip()
        {
            _transform.position = Vector3.Lerp(_transform.position, desiredPosition, smoothSpeed);

            var desiredRotation = _transform.rotation;

            desiredRotation.y = Mathf.Lerp(desiredRotation.y, -180, rotationSmoothSpeed * Time.deltaTime);

            _transform.rotation = desiredRotation;
        }


        [ContextMenu("Start Flipping")]
        public void StartFlipping()
        {
            _canFlip = true;
            Instantiate(gameObject, _originalPosition, Quaternion.identity);
        }

        [ContextMenu("Stop Flipping")]
        public void StopFlipping()
        {
            _canFlip = false;
        }
    }
}