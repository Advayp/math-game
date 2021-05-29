using MathGame.Core;
using UnityEngine;

namespace MathGame.Managers
{
    public class AnswerDetermine : MonoBehaviour, IAnswerDetermine
    {
        [SerializeField] private Question mainQuestion;
        [SerializeField] private AnswerChecker correctAnswer;

        [Header("Colors")]
        [SerializeField] private Color correctColor;

        [SerializeField] private Color wrongColor;

        private Tries _tries;

        private void Start()
        {
            _tries = new Tries(mainQuestion.tries);
        }

        public void HandleCorrectAnswer(AnswerChecker answer)
        {
            answer.ChangeImageColor(correctColor);
        }

        public bool HandleWrongAnswer(AnswerChecker answer)
        {
            answer.ChangeImageColor(wrongColor);

            if (_tries.UseTry()) return true;

            correctAnswer.ChangeImageColor(correctColor);
            return false;
        }

        public void ShowCorrectAnswer()
        {
            correctAnswer.ChangeImageColor(correctColor);
        }

        public bool IsWrongAnswer(AnswerChecker answer)
        {
            return answer.answerToCheck != correctAnswer.answerToCheck;
        }
    }
}