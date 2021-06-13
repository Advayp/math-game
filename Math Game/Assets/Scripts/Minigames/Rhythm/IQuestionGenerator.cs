namespace Discovery.Minigames.Rhythm
{
    public interface IQuestionGenerator
    {
        int Answer { get; }
        string GetQuestion();
    }
}