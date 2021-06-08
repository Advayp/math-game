using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter
{
    public interface IPlayerInput
    {
        Vector2 GetInput();
        bool GetJump();
    }
}