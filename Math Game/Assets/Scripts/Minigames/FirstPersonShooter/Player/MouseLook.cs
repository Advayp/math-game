using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.Player
{
    public class MouseLook : MonoBehaviour, IEnableable
    {
        [SerializeField] private float mouseSensitivity;
        [SerializeField] private Transform player;

        private float _xRotation;
        private bool _isEnabled = true;

        private void Update()
        {
            if (_isEnabled == false) return;
            
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            var rot = transform.localRotation.eulerAngles;
            var desiredX = rot.y + mouseX;
            

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);
            transform.rotation = Quaternion.Euler(_xRotation, desiredX, 0);
            player.localRotation = Quaternion.Euler(0, desiredX, 0);
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}