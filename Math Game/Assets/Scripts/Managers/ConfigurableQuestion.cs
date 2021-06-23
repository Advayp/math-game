using System;

namespace Discovery.Managers
{
    [Serializable]
    public struct ConfigurableQuestion
    {
        public QuestionDisplayer displayer;
        public AnswerDetermine answerDetermine;
        public ScoreManager scoreManager;

        public void Initialize(Question question)
        {
            displayer.Initialize(question);
            scoreManager.Initialize(question.pointsRewarded);
        }

        public void Initialize(Question question, AnswerChecker correctAnswer)
        {
            answerDetermine.Initialize(question, correctAnswer);
        }
    }   
}