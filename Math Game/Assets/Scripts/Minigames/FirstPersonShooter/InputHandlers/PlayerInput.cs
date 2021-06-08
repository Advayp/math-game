using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.InputHandlers
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        public Vector2 GetInput()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        public bool GetJump()
        {
            return Input.GetButtonDown("Jump");
        }
    }
}