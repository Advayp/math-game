using UnityEngine;
using System.Collections.Generic;
using System;

namespace MathGame.Core
{
    public class AnswerManager : MonoBehaviour
    {
        public Question MainQuestion;
        [SerializeField] private Color CorrectColor;
        [SerializeField] private Color WrongColor;
        [SerializeField] private AnswerChecker _correctAnswer;
        [SerializeField] private List<AnswerChecker> _answerCheckers;
        [SerializeField] private FloatVariable _score;
        [SerializeField] private Timer _timer;

        // Made Static Because I want each of the different Instances of the AnswerManager
        // to call the same methods subscribed to the Scored event
        public static event Action Scored;

        private Tries _tries;

        private void Start()
        {
            _tries = new Tries(MainQuestion.Tries);
            _timer.StartTimer(MainQuestion.Seconds);
        }

        private void Update()
        {
            if (_timer.IsComplete == false) return;
            ShowAnswer();
        }

        public void Check(AnswerChecker answer)
        {
            if (MainQuestion.CorrectAnswer != answer.AnswerToCheck)
            {
                answer.ChangeImageColor(WrongColor);

                if (_tries.UseTry()) return;
                _correctAnswer.ChangeImageColor(CorrectColor);

                _score.Value = Mathf.Clamp(_score.Value - MainQuestion.PointsRewarded, 0, int.MaxValue);
            }
            else
            {
                answer.ChangeImageColor(CorrectColor);
                _score.Value += MainQuestion.PointsRewarded;
            }

            _timer.StopTimer();
            Scored?.Invoke();
            DisableAllAnswerButtons();
        }

        private void ShowAnswer()
        {
            _correctAnswer.ChangeImageColor(CorrectColor);
            DisableAllAnswerButtons();
            _timer.StopTimer();
            Scored?.Invoke();
        }

        private void DisableAllAnswerButtons()
        {
            foreach (AnswerChecker answerChecker in _answerCheckers)
            {
                answerChecker.AnswerButton.interactable = false;
            }
        }

        #region Editor Functions

        public void ChangeToCorrect()
        {
            foreach (AnswerChecker answerChecker in _answerCheckers)
            {
                answerChecker.ChangeImageColor(CorrectColor);
            }
        }

        public void ChangeToWrong()
        {
            foreach (AnswerChecker answerChecker in _answerCheckers)
            {
                answerChecker.ChangeImageColor(WrongColor);
            }
        }

        public void ChangeToDefault()
        {
            foreach (AnswerChecker answerChecker in _answerCheckers)
            {
                answerChecker.ChangeImageColor(Color.white);
            }
        }

        #endregion Editor Functions
    }
}