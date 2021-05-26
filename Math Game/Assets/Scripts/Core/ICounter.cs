namespace MathGame.Managers
{
	public interface ICounter
	{
		int Count { get; }
		bool HasReachedMax { get; set; }

		void Increment();
	}
}