namespace Discovery.Minigames.CardGame.QuestionLogic
{
    public interface IAnswerDisplay
    {
        void InitializeText(PlayerType playerType);
        bool IsQuestionActive { get;  }
    }
}