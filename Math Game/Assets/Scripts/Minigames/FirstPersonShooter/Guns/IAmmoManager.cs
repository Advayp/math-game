namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public interface IAmmoManager
    {
        bool NeedsToReload { get; }
        int CurrentAmmoCount { get; }
        bool IsReloading { get; }
        bool UseBullet();
        void StopReloading();
        void StartReloading();
    }
}