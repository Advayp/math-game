namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public interface IReloadTimeCalculator
    {
        int Calculate(int maxAmmo);
    }
}