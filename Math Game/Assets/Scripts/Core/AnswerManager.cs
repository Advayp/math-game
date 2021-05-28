using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.Serialization;

namespace MathGame.Core
{
    public class AnswerManager : MonoBehaviour
    {
        [FormerlySerializedAs("MainQuestion")]
        public Question mainQuestion;

        [FormerlySerializedAs("CorrectColor")]
        [SerializeField]
        public Color correctColor;

        [FormerlySerializedAs("WrongColor")]
        [SerializeField]
        public Color wrongColor;

        [FormerlySerializedAs("_correctAnswer")]
        [SerializeField]
        public AnswerChecker correctAnswer;

        [FormerlySerializedAs("_answerCheckers")]
        [SerializeField] private List<AnswerChecker> answerCheckers;

        [FormerlySerializedAs("_score")]
        [SerializeField] private FloatVariable score;

        [FormerlySerializedAs("_timer")]
        [SerializeField] private Timer timer;


        // Made Static Because I want each of the different Instances of the AnswerManager
        // to call the same methods subscribed to the Scored event
        public static event Action Scored;

        private Tries _tries;

        private void Start()
        {
            _tries = new Tries(mainQuestion.tries);
            timer.StartTimer(mainQuestion.seconds);
        }

        private void Update()
        {
            if (timer.IsComplete == false) return;
            ShowAnswer();
        }

        public void Check(AnswerChecker answer)
        {
            if (mainQuestion.correctAnswer != answer.answerToCheck)
            {
                answer.ChangeImageColor(wrongColor);

                if (_tries.UseTry()) return;

                correctAnswer.ChangeImageColor(correctColor);

                score.value = Mathf.Clamp(score.value - mainQuestion.pointsRewarded, 0, int.MaxValue);
            }
            else
            {
                answer.ChangeImageColor(correctColor);
                score.value += mainQuestion.pointsRewarded;
            }

            timer.StopTimer();
            Scored?.Invoke();
            DisableAllAnswerButtons();
        }

        private void ShowAnswer()
        {
            correctAnswer.ChangeImageColor(correctColor);
            DisableAllAnswerButtons();
            timer.StopTimer();
            Scored?.Invoke();
        }

        private void DisableAllAnswerButtons()
        {
            foreach (var answerChecker in answerCheckers)
            {
                answerChecker.answerButton.interactable = false;
            }
        }

        public void UseTriesPowerUp()
        {
            PowerUpManager.Use(PowerUpType.Tries, ref _tries.RemainingTries);
        }
        

        #region Editor Functions

        public void ChangeToCorrect()
        {
            foreach (var answerChecker in answerCheckers)
            {
                answerChecker.ChangeImageColor(correctColor);
            }
        }

        public void ChangeToWrong()
        {
            foreach (var answerChecker in answerCheckers)
            {
                answerChecker.ChangeImageColor(wrongColor);
            }
        }

        public void ChangeToDefault()
        {
            foreach (var answerChecker in answerCheckers)
            {
                answerChecker.ChangeImageColor(Color.white);
            }
        }

        #endregion Editor Functions
    }
}