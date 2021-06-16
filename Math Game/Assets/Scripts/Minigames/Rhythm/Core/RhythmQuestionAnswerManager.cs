using System;
using TMPro;
using UnityEngine;

namespace Discovery.Minigames.Rhythm
{
    [RequireComponent(typeof(TMP_Text))]
    public class RhythmQuestionAnswerManager : MonoBehaviour, IEnableable
    {
        [SerializeField, Header("Dependencies"), Space] private FallingCube cubeToTrack;
        [SerializeField, Header("Config"), Space] private KeyCode keyToPress;


        [HideInInspector] public int value;

        public event Action Answered;
        public event Action AnsweredCorrectly;

        private TMP_Text _label;
        private int _correctAnswer;
        private RectTransform _rectTransform;
        private bool _isEnabled = true;

        public bool IsCorrect => _correctAnswer == value;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
            _rectTransform = GetComponent<RectTransform>();

            cubeToTrack.Require(this);
        }

        private void Start()
        {
           cubeToTrack.Initialize(_rectTransform); 
        }

        public void Initialize(int answer, int correctAnswer)
        {
            value = answer;
            _correctAnswer = correctAnswer;
            _label.SetText(value.ToString());
        }

        private void Update()
        {
            if (_isEnabled == false) return;
            
            if (!Input.GetKeyDown(keyToPress) || cubeToTrack.IsCloseEnough == false)
                return;

            if (IsCorrect)
            {
                Debug.Log("Correct!");
                AnsweredCorrectly?.Invoke();
            }
            else
            {
                Debug.Log($"Wrong. Correct Answer is {_correctAnswer}");
            }

            Answered?.Invoke();
        }

        public void ChangeTextColor(Color color)
        {
            _label.color = color;
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