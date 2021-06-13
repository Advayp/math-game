using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter
{
    public interface IPlayerInput
    {
        Vector2 GetInput();
        bool GetJump();
    }
}