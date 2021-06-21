using Discovery.Minigames.FirstPersonShooter.Guns;

namespace Tests.EditMode
{
    public class ChargeDamageCalculatorBuilder
    {
        private StandardChargeDamageCalculator Build()
        {
            return new StandardChargeDamageCalculator();
        }

        public static implicit operator StandardChargeDamageCalculator(ChargeDamageCalculatorBuilder builder)
        {
            return builder.Build();
        }
    }
}