namespace MathGame.Managers
{
	public class MaxInclusiveCounter : ICounter
	{
		public int Count { get; private set; }
		public bool HasReachedMax { get; set; }

		private readonly int _maxCount;

		public MaxInclusiveCounter(int startValue, int maxCount)
		{
			HasReachedMax = false;
			Count = startValue;
			_maxCount = maxCount;
		}

		public void Increment()
		{
			if (Count + 1 > _maxCount)
			{
				Count = _maxCount;
				HasReachedMax = true;
				return;
			}
			Count++;
		}
	}
}