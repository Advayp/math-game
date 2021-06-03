namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public interface IAmmoManager
    {
        int CurrentAmmoCount { get; }
        bool IsReloading { get; }
        bool UseBullet();
        void StopReloading();
        void StartReloading();
    }
}