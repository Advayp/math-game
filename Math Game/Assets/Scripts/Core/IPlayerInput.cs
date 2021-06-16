using UnityEngine;

namespace Discovery
{
    public interface IPlayerInput
    {
        Vector2 GetInput();
        bool GetJump();
    }
}