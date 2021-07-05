using UnityEngine;

namespace Discovery.UI
{
    public class FadeInPanel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup group;
        [SerializeField] private float duration = 0.2f;
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenFadingOut;
        


        public void FadeIn()
        {
            group.alpha = 0;
            LeanTween.alphaCanvas(group, 1, duration).setDelay(delay);
        }

        public void FadeInThenOut()
        {
            group.alpha = 0;
            LeanTween.alphaCanvas(group, 1, duration)
                .setDelay(delay);
            Invoke(nameof(FadeOut), delayBetweenFadingOut);
        }

        public void FadeOut()
        {
            LeanTween.alphaCanvas(group, 0, duration)
                .setDelay(delay);
        }
    }
}