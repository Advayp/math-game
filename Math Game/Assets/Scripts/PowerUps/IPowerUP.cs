namespace MathGame.PowerUps
{
    public interface IPowerUp<T>
    {
        void Use(ref T amount);

        int GetInfo();
    }
}