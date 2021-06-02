namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public interface IAmmoManager
    {
        bool IsReloading { get; set; }
        bool UseBullet();
        void StopReloading();
        void StartReloading();
    }
}