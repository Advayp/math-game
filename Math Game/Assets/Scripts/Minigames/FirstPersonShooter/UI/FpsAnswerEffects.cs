using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Discovery.Minigames.FirstPersonShooter.UI
{
    [RequireComponent(typeof(Animator))]
    public class FpsAnswerEffects : MonoBehaviour
    {
        [SerializeField] private AnimationClip clip;

        [SerializeField, Tooltip("The Image which you want to show when the user gets a correct answer.")]
        private Image correctAnswerImage;

        [SerializeField, Tooltip("The Image which you want to show when the user answers wrongly.")]
        private Image wrongAnswerImage;


        private Animator _animator;
        private static readonly int IsWrong = Animator.StringToHash("IsWrong");
        private WaitForSeconds _stopDuration;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _stopDuration = new WaitForSeconds(clip.length);
        }

        private void OnEnable()
        {
           correctAnswerImage.gameObject.SetActive(false); 
           wrongAnswerImage.gameObject.SetActive(false);
        }

        public void ShowCorrectAnswerImage()
        {
            correctAnswerImage.gameObject.SetActive(true);
            wrongAnswerImage.gameObject.SetActive(false);
        }

        public void ShowWrongAnswerImage()
        {
            wrongAnswerImage.gameObject.SetActive(true);
            correctAnswerImage.gameObject.SetActive(false);
        }

        public void PlayAnimation()
        {
            _animator.SetBool(IsWrong, true);
            StartCoroutine(StopAnimationCoroutine());
        }

        private IEnumerator StopAnimationCoroutine()
        {
            yield return _stopDuration;
            _animator.SetBool(IsWrong, false);
        }
    }
}