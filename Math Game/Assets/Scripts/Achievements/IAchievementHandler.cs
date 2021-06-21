namespace Discovery.Achievements
{
    public interface IAchievementHandler
    {
        bool Check(Achievements achievement);
        string GetText();
        AchievementType Type { get; }
    }   
}