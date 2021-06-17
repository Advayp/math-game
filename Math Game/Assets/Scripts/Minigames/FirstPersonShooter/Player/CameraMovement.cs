using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Player
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerHead;


        private void Awake()
        {
           playerHead.Require(this); 
        }

        private void Update()
        {
            transform.position = playerHead.position;
        }
    }
}
