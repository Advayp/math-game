namespace MathGame
{
    public interface IManageScore
    {
        void IncreaseScore();

        void LowerScore();

        FloatVariable Score { get; }

    }
}