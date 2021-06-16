using Discovery.Minigames.FirstPersonShooter.Player;

namespace Discovery.Minigames.Platformer
{
    public class PlatformerPlayerController : PlayerMovement, IJumpable, IControllable
    {
        public int NumberOfJumps => CurrentNumberOfJumps;

        public void SetJumps(int amount)
        {
            maxJumps = amount;
            CurrentNumberOfJumps = maxJumps;
        }

        public void SetSpeed(float amount)
        {
            moveSpeed = amount;
            RecalculateMoveSpeed();
        }
    }
}