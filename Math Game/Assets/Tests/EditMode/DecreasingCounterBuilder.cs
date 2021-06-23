using Discovery;

namespace Tests.EditMode
{
    public class DecreasingCounterBuilder
    {
        private int _currentCount, _maxCount, _minCount;

        public DecreasingCounterBuilder WithCurrentCount(int currentCount)
        {
            _currentCount = currentCount;
            return this;
        }

        public DecreasingCounterBuilder WithMaxCount(int maxCount)
        {
            _maxCount = maxCount;
            return this;
        }

        public DecreasingCounterBuilder WithMinCount(int minCount)
        {
            _minCount = minCount;
            return this;
        }

        private StandardDecreasingCounter Build()
        {
            return new StandardDecreasingCounter(_currentCount, _minCount, _maxCount);
        }

        public static implicit operator StandardDecreasingCounter(DecreasingCounterBuilder builder)
        {
            return builder.Build();
        }
    }
}