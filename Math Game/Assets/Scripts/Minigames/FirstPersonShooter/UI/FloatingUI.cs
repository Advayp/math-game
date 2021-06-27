using UnityEngine;

namespace Discovery.Minigames.FirstPersonShooter.UI
{
    public class FloatingUI : MonoBehaviour
    {
        [SerializeField, Header("Config")] private Transform target;

        [SerializeField] private Vector3 offset;

        [SerializeField] private Camera mainCamera;

        private void Awake()
        {
            mainCamera = mainCamera ? mainCamera : Camera.main;
        }

        private void Update()
        {
            if (FpsQuestionManager.IsQuestionDisplaying) return;

            var desiredPosition = mainCamera.WorldToScreenPoint(target.position + offset);

            if (transform.position != desiredPosition)
            {
                transform.position = desiredPosition;
            }
        }
    }
}