using MathGame.Minigames.FirstPersonShooter.Core;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.InputHandlers
{
    public class GunInputHandler : MonoBehaviour, IGunInput
    {
        public bool GetInput()
        {
            return Input.GetButton("Fire1");
        }
    }
}