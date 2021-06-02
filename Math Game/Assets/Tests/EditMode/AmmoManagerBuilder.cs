using MathGame.Minigames.FirstPersonShooter.Guns;

namespace Tests.EditMode
{
    public class AmmoManagerBuilder
    {
        private int _maxCount;

        public AmmoManagerBuilder WithMaxCount(int maxCount)
        {
            _maxCount = maxCount;
            return this;
        }

        private AmmoManager Build()
        {
            return new AmmoManager(_maxCount);
        }

        public static implicit operator AmmoManager(AmmoManagerBuilder builder)
        {
            return builder.Build();
        }
    }
}