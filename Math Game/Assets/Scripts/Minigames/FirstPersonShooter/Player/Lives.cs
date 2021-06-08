using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Player
{
    public class Lives : Tries
    {
        public Lives(int maxTries) : base(maxTries)
        {
        }

        public override bool UseTry()
        {
            remainingTries--;
            remainingTries = Mathf.Clamp(remainingTries, 0, int.MaxValue);
            return remainingTries > 0;
        }
    }
}