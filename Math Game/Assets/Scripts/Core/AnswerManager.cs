using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MathGame
{
    public class AnswerManager : MonoBehaviour
    {
        #region Inspector Fields

        [FormerlySerializedAs("MainQuestion")]
        public Question mainQuestion;

        [FormerlySerializedAs("_correctAnswer")]
        [SerializeField]
        public AnswerChecker correctAnswer;

        [FormerlySerializedAs("_answerCheckers")]
        [SerializeField] private List<AnswerChecker> answerCheckers;

        [FormerlySerializedAs("_timer")]
        [SerializeField] private Timer timer;

        #endregion Inspector Fields

        // Made Static Because I want each of the different Instances of the AnswerManager
        // to call the same methods subscribed to the Scored event
        public static event Action Scored;
        public static event Action QuestionCompleted;

        private IAnswerDetermine _answerDetermine;
        private IManageScore _scoreManager;

        private void Awake()
        {
            _answerDetermine = GetComponent<IAnswerDetermine>();
            _scoreManager = GetComponent<IManageScore>();
        }

        private void Start()
        {
            timer.Start(mainQuestion.seconds + 1);
        }

        private void OnEnable()
        {
            if (_answerDetermine.HasQuestionBeenAnswered) return;
            timer.Resume();
        }

        private void Update()
        {
            if (timer.IsComplete == false) return;
            ShowAnswer();
        }

        public void Check(AnswerChecker answer)
        {
            if (_answerDetermine.IsWrongAnswer(answer))
            {
                if (_answerDetermine.HandleWrongAnswer(answer)) return;

                _scoreManager.LowerScore();
            }
            else
            {
                _answerDetermine.HandleCorrectAnswer(answer);

                _scoreManager.IncreaseScore();
            }

            timer.Stop();
            Scored?.Invoke();
            QuestionCompleted?.Invoke();
            DisableAllAnswerButtons();
        }


        private void ShowAnswer()
        {
            _answerDetermine.ShowCorrectAnswer();
            DisableAllAnswerButtons();
            timer.Stop();
            Scored?.Invoke();
            QuestionCompleted?.Invoke();
        }

        private void DisableAllAnswerButtons()
        {
            foreach (var answerChecker in answerCheckers)
            {
                answerChecker.answerButton.interactable = false;
            }
        }

        public void UseScorePowerUp()
        {
            PowerUpManager.UseScore(ref _scoreManager.Score.value);
            Scored?.Invoke();
        }
        
    }
}