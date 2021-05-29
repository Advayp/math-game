using MathGame.PowerUps;

namespace Tests.EditMode
{
    public class TimerPowerUpBuilder
    {
        private int _addedValue;

        public TimerPowerUpBuilder WithAddedValue(int amount)
        {
            _addedValue = amount;
            return this;
        }

        private TimePowerUp Build()
        {
            return new TimePowerUp(_addedValue);
        }

        public static implicit operator TimePowerUp(TimerPowerUpBuilder builder)
        {
            return builder.Build();
        }
    }
}