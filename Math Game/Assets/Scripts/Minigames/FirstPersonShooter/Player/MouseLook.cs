using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Player
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity;
        [SerializeField] private Transform player;

        private float _xRotation;

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            var rot = transform.localRotation.eulerAngles;
            var desiredX = rot.y + mouseX;
            

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);
            transform.rotation = Quaternion.Euler(_xRotation, desiredX, 0);
            player.localRotation = Quaternion.Euler(0, desiredX, 0);
        }
    }
}