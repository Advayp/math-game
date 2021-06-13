using Discovery.Minigames.FirstPersonShooter.Guns;

namespace Tests.EditMode
{
    public class AmmoManagerBuilder
    {
        private int _maxCount;

        public AmmoManagerBuilder WithMax(int newMax)
        {
            _maxCount = newMax;
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