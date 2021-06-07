using MathGame.Minigames.FirstPersonShooter.Guns;

namespace Tests.EditMode
{
    public class ReloadCalculatorBuilder
    {
        private MultipleOfTenReloadTimeCalculator Build()
        {
            return new MultipleOfTenReloadTimeCalculator();
        }

        public static implicit operator MultipleOfTenReloadTimeCalculator(ReloadCalculatorBuilder builder)
        {
            return builder.Build();
        }
    }
}