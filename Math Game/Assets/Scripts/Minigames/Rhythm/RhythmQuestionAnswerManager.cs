using System;
using TMPro;
using UnityEngine;

namespace Discovery.Minigames.Rhythm
{
    [RequireComponent(typeof(TMP_Text))]
    public class RhythmQuestionAnswerManager : MonoBehaviour
    {
        [SerializeField] private KeyCode keyToPress;

        [HideInInspector] public int value;

        public event Action Answered;
        
        private TMP_Text _label;
        private int _correctAnswer;

        private bool IsCorrect => _correctAnswer == value;

        private void Awake()
        {
            _label = GetComponent<TMP_Text>();
        }

        public void Initialize(int answer, int correctAnswer)
        {
            value = answer;
            _correctAnswer = correctAnswer;
            _label.SetText(value.ToString());
        }

        private void Update()
        {
            if (!Input.GetKeyDown(keyToPress))
                return;
            
            Debug.Log(IsCorrect ? "Correct" : $"Wrong, Correct Answer is {_correctAnswer}");
            Answered?.Invoke();
        }

    }
}