using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Discovery.Achievements
{
    [RequireComponent(typeof(Animator))]
    public class StandardAchievementDisplay : MonoBehaviour, IAchievementDisplay
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private AnimationClip fadeInClip;
        [SerializeField] private List<string> unhandledAnimations = new List<string>();

        private IEnumerator _currentAchievement;
        private Animator _animator;
        private static readonly int IsDisplaying = Animator.StringToHash("IsDisplaying");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (unhandledAnimations.Count == 0 || _currentAchievement != null)
            {
                return;
            }
            _currentAchievement = DisplayAllCoroutine();
            StartCoroutine(DisplayAllCoroutine());
        }

        private IEnumerator DisplayAllCoroutine()
        {
            _animator.SetBool(IsDisplaying, true);
            foreach (var unhandledAnimation in unhandledAnimations)
            {
                label.SetText(unhandledAnimation);
                yield return new WaitForSeconds(fadeInClip.length);
            }
            _animator.SetBool(IsDisplaying, false);
            unhandledAnimations.Clear();
            _currentAchievement = null;
        }
        
        public void Initialize(string achievementText)
        {
            unhandledAnimations.Add($"<color=#F6E58D>{achievementText}</color>");
        }

        public void Display()
        {
        }
        
        
    }
}