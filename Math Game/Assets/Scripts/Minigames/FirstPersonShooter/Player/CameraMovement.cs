using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter.Player
{
    public class CameraMovement : MonoBehaviour, IEnableable
    {
        [SerializeField] private Transform playerHead;

        private bool _isEnabled = true;
        
        private void Update()
        {
            if (_isEnabled == false) return;
            transform.position = playerHead.position;
        }

        public void Enable() => _isEnabled = true;
        public void Disable() => _isEnabled = false;
    }
}
