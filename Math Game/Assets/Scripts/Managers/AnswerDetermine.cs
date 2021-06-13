using UnityEngine;

namespace Discovery.Managers
{
    public class AnswerDetermine : MonoBehaviour, IAnswerDetermine
    {
        [SerializeField] private Question mainQuestion;
        [SerializeField] private AnswerChecker correctAnswer;

        [Header("Colors")]
        [SerializeField]
        private Color correctColor;

        [SerializeField] private Color wrongColor;


        public bool HasQuestionBeenAnswered { get; private set; }
        private Tries _tries;

        private void Start()
        {
            _tries = new Tries(mainQuestion.tries);
            HasQuestionBeenAnswered = false;
        }

        public void HandleCorrectAnswer(AnswerChecker answer)
        {
            HasQuestionBeenAnswered = true;
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

        public void UseTries()
        {
           PowerUpManager.UseTries(ref _tries.remainingTries); 
        }
    }
}