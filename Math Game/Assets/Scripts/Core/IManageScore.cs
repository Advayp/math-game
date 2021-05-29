using System;

namespace MathGame.Core
{
    public interface IManageScore
    {
        void IncreaseScore();

        void LowerScore();

        FloatVariable Score { get; set; }

    }
}