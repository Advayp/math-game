namespace Discovery
{
    public interface IManageScore
    {
        void IncreaseScore();

        void LowerScore();

        FloatVariable Score { get; }

    }
}