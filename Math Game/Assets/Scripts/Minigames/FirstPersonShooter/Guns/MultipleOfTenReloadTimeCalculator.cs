using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Guns
{
    public class MultipleOfTenReloadTimeCalculator : IReloadTimeCalculator
    {
        public int Calculate(int maxAmmo)
        {
            return Mathf.RoundToInt((float) maxAmmo / 50);
        }
    }
}