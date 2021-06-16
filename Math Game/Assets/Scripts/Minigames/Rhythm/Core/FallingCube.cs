using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Discovery.Minigames.Rhythm
{
    public class FallingCube : MonoBehaviour, IEnableable
    {
        private const int MinSpeed = 1;
        private const int MaxSpeed = 3;

        [Serializable]
        private enum Direction
        {
            Up,
            Down,
        }

        [SerializeField, Header("Config"), Space]
        private float lowestToleratedValue;

        [SerializeField] private float highestToleratedValue;


        [SerializeField, Tooltip("The lowest y-value to lerp to.")]
        private float startValue;

        [SerializeField, Tooltip("The highest y-value to lerp to.")]
        private float endValue;

        [SerializeField, Range(MinSpeed, MaxSpeed)]
        [Tooltip("The speed to lerp between the 2 y-values. This value is overriden if \"Use random value\" is selected.")]
        private float smoothSpeed;

        [SerializeField, Tooltip("The direction in which the cube is moving in.")]
        private Direction direction = Direction.Up;

        [SerializeField, Tooltip("If selected, the smooth speed will be assigned a random value.")]
        private bool useRandomValue;

        [SerializeField, Range(0, 1)]
        [Tooltip("The distance required from either the start or end point for the cube to change direction.")]
        private float tolerance;



        [SerializeField, Header("Debug"), Space]
        private bool showClosenessStatus;

        private float _offset;
        private float _desiredYValue;
        private RectTransform _answerManager;
        private bool _isEnabled;

        public bool IsCloseEnough => 
            transform.position.y >= lowestToleratedValue && transform.position.y <= highestToleratedValue;


        private void Start()
        {
            if (useRandomValue == false) return;
            smoothSpeed = Random.Range(MinSpeed, MaxSpeed);
        }

        private void Update()
        {
            if (_isEnabled == false) return;
            
            if (showClosenessStatus)
            {
                print(transform.position.y + _offset);
            }

            var position = transform.position;

            var desiredValueToGoTo = direction == Direction.Up ? endValue : startValue;
            
            _desiredYValue = Mathf.Lerp(position.y, desiredValueToGoTo, smoothSpeed * Time.deltaTime);

            if (Math.Abs(_desiredYValue - endValue) < tolerance)
            {
                direction = Direction.Down;
            }
            else if (Math.Abs(_desiredYValue - startValue) < tolerance)
            {
                direction = Direction.Up;
            }

            position = new Vector3(position.x, _desiredYValue, position.z);
            transform.position = position;

        }

        public void Initialize(RectTransform answerManager)
        {
            _answerManager = answerManager;
            _offset = _answerManager.position.y - transform.position.y;
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}