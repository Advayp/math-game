using UnityEngine;

namespace Discovery.UI
{
    public class Notification : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            var position = transform.position;
            position.x = -Screen.width / 8f;
            _rectTransform.position = position;
        }

        private void OnComplete()
        {
            
            LeanTween.delayedCall(1f, () =>
            {
                LeanTween.moveLocalX(gameObject, -Screen.width, 0.7f);
            });
        }
        
        [ContextMenu("Go To Desired Position")]
        public void GoToDesiredPosition()
        {
            LeanTween.moveLocalX(gameObject, 0, 0.6f).setOnComplete(OnComplete);
        }
    }
}