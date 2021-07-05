using UnityEngine;
using UnityEngine.Events;

namespace Discovery.UI
{
    public class ScaleElement : MonoBehaviour
    {
        [SerializeField] private Vector3 desiredScale;
        [SerializeField] private float duration;
        [SerializeField] private float delay;
        
        [SerializeField] private UnityEvent onCompleteCallback;

        private Vector3 _originalScale;

        private void Start()
        {
            _originalScale = transform.localScale;
        }

        public void ScaleIn()
        {
            LeanTween.scale(gameObject, desiredScale, duration).setOnComplete(() =>
            {
                onCompleteCallback?.Invoke();
            }).setDelay(delay);
        }

        public void ScaleOut()
        {
            LeanTween.scale(gameObject, _originalScale, duration).setDelay(delay);
        }
    }
}