namespace MathGame.Core
{
    public interface IAnswerDetermine
    {
        bool HasQuestionBeenAnswered { get; }
        void HandleCorrectAnswer(AnswerChecker answer);

        bool HandleWrongAnswer(AnswerChecker answer);

        void ShowCorrectAnswer();

        bool IsWrongAnswer(AnswerChecker answer);

        void UseTries();
    }
}