using MathGame.Managers;

// Builder Pattern
namespace Tests.EditMode
{
	public class CounterBuilder
	{
		private int _startValue;
		private int _maxValue;

		public CounterBuilder WithStartValue(int startValue)
		{
			_startValue = startValue;
			return this;
		}

		public CounterBuilder WithMaxValue(int maxValue)
		{
			_maxValue = maxValue;
			return this;
		}

		public MaxInclusiveCounter Build()
		{
			return new MaxInclusiveCounter(_startValue, _maxValue);
		}

		public static implicit operator MaxInclusiveCounter(CounterBuilder builder)
		{
			return builder.Build();
		}
	}
}