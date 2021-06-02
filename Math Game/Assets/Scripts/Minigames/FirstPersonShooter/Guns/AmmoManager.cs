namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public class AmmoManager : IAmmoManager
    {
        public bool IsReloading { get; set; }
        
        private int _currentAmmoCount;
        private readonly int _maxCount;

        public AmmoManager(int maxCount)
        {
            _maxCount = maxCount;
            _currentAmmoCount = maxCount;
            IsReloading = false;
        }


        public bool UseBullet()
        {
            _currentAmmoCount--;
            return _currentAmmoCount >= 0;
        }

        public void StopReloading()
        {
            IsReloading = false;
            _currentAmmoCount = _maxCount;
        }

        public void StartReloading()
        {
            IsReloading = true;
        }
    }
}