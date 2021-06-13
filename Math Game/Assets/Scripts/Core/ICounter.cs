namespace Discovery
{
	public interface ICounter
	{
		int Count { get; }
		bool HasReachedMax { get; }

		void Increment();
	}
}