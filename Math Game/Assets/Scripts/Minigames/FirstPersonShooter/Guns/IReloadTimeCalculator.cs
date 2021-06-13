namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public interface IReloadTimeCalculator
    {
        int Calculate(int maxAmmo);
    }
}