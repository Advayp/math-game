using UnityEngine;

namespace Discovery.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FullScreenNotification : MonoBehaviour
    {
        [SerializeField] private float fadeTime = 0.5f;
        [SerializeField] private float delayBetweenFadingOut = 0.7f;
        
        private CanvasGroup _group;

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();
        }

        private void OnComplete()
        {
            LeanTween.delayedCall(delayBetweenFadingOut, () =>
            {
                LeanTween.alphaCanvas(_group, 0, fadeTime);
            });
        }

        [ContextMenu("Fade In")]
        public void FadeIn()
        {
            _group.alpha = 0;
            LeanTween.alphaCanvas(_group, 1, fadeTime).setOnComplete(OnComplete);
        }
    }
}