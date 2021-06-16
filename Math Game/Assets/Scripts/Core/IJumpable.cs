namespace Discovery
{
    public interface IJumpable
    {
        int NumberOfJumps { get; }
        void SetJumps(int amount);
    }
}