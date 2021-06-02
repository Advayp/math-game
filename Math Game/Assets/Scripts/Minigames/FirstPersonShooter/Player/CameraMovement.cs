using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Player
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerHead;

        private void Update()
        {
            transform.position = playerHead.position;
        }
    }
}
