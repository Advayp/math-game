namespace MathGame.Managers
{
	public interface ICounter
	{
		int Count { get; set; }
		bool HasReachedMax { get; set; }

		void Increment();
	}
}