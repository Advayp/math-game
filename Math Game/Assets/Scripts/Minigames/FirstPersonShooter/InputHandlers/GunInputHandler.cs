

using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.InputHandlers
{
    public class GunInputHandler : MonoBehaviour, IGunInput
    {
        public bool GetInput()
        {
#if UNITY_EDITOR
            return Input.GetButton("Fire1") || Input.GetKey(KeyCode.E);
#else
            return Input.GetButton("Fire1");
#endif
        }
    }
}