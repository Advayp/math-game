namespace Discovery.Minigames.CardGame.QuestionLogic
{
    public interface ICheckAnswer
    {
        void Initialize(int answer);
        void Check(string text);
    }
}