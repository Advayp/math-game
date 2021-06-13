using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public class MultipleOfTenReloadTimeCalculator : IReloadTimeCalculator
    {
        public int Calculate(int maxAmmo)
        {
            return Mathf.RoundToInt((float) maxAmmo / 50);
        }
    }
}