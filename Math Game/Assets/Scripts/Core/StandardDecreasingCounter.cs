namespace Discovery
{
    public class StandardDecreasingCounter : IBackwardsCounter
    {
        private readonly int _maxCount;
        private readonly int _minCount;

        public int Count { get; private set; }
        public bool HasReachedMax { get; private set; }
        public bool HasReachedMin { get; private set; }

        public StandardDecreasingCounter(int currentCount, int minCount, int maxCount)
        {
            Count = currentCount;
            _maxCount = maxCount;
            _minCount = minCount;
            HasReachedMax = false;
            HasReachedMin = false;
        }

        public void Increment()
        {
            HasReachedMin = false;
            if (Count + 1 >= _maxCount)
            {
                Count = _maxCount;
                HasReachedMax = true;
                return;
            }
            Count++;
        }


        public void Decrement()
        {
            HasReachedMax = false;
            if (Count - 1 <= _minCount)
            {
                Count = _minCount;
                HasReachedMin = true;
                return;
            }
            Count--;
        }
    }
}