﻿namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public class AmmoManager : IAmmoManager
    {
        public int CurrentAmmoCount { get; private set; }

        public bool IsReloading { get; private set; }

        private readonly int _maxCount;

        public AmmoManager(int maxCount)
        {
            _maxCount = maxCount;
            CurrentAmmoCount = maxCount;
            IsReloading = false;
        }


        public bool UseBullet()
        {
            CurrentAmmoCount--;
            return CurrentAmmoCount >= 0;
        }

        public void StopReloading()
        {
            IsReloading = false;
            CurrentAmmoCount = _maxCount;
        }

        public void StartReloading()
        {
            IsReloading = true;
        }
    }
}