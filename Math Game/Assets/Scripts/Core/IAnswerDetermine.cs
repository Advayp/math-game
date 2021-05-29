namespace MathGame.Core
{
    public interface IAnswerDetermine
    {
        void HandleCorrectAnswer(AnswerChecker answer);

        bool HandleWrongAnswer(AnswerChecker answer);

        void ShowCorrectAnswer();

        bool IsWrongAnswer(AnswerChecker answer);
    }
}