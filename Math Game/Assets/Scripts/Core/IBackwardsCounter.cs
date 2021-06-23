namespace Discovery
{
    public interface IBackwardsCounter : ICounter
    {
        bool HasReachedMin { get;  }
        void Decrement();
    }
}