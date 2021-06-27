using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class FpsQuestionManager : MonoBehaviour
    {
        [SerializeField] private QuestionDisplayer[] questionDisplays;
        [SerializeField] private GameObject[] objectsToDisable;

        [SerializeField, Tooltip("The delay before the question that is currently displaying disappears.")]
        private float delay = 0.3f;

        public static bool IsQuestionDisplaying;

        private QuestionDisplayer _currentQuestion;

        private readonly Dictionary<GameObject, IEnableable[]> _enableables =
            new Dictionary<GameObject, IEnableable[]>();

        private WaitForSeconds _hideQuestionDelay;
        

        private void Awake()
        {
            foreach (var objectToDisable in objectsToDisable)
            {
                var enableables = objectToDisable.GetComponents<IEnableable>();
                _enableables.Add(objectToDisable, enableables);
            }
        }

        private void Start()
        {
            _hideQuestionDelay = new WaitForSeconds(delay);
        }

        private void OnEnable()
        {
            EnemyHealth.OnDeath += ShowQuestion;
        }

        private void OnDisable()
        {
            EnemyHealth.OnDeath -= ShowQuestion;
        }

        private void ShowQuestion()
        {
            if (UnityEngine.Random.value > 0.3f) return;
            
            var random = new Random();
            var index = random.Next(questionDisplays.Length);
            _currentQuestion = questionDisplays[index];

            _currentQuestion.Show();
            IsQuestionDisplaying = true;
            ChangeState(e => { e.Disable(); });
        }

        private void ChangeState(Action<IEnableable> action)
        {
            foreach (var objectToDisable in objectsToDisable)
            {
                foreach (var enableable in _enableables[objectToDisable])
                {
                    action(enableable);
                }
            }
        }

        public void HideQuestion()
        {
            StartCoroutine(HideQuestionCoroutine());
        }

        private IEnumerator HideQuestionCoroutine()
        {
            yield return _hideQuestionDelay;
            _currentQuestion.Hide();
            IsQuestionDisplaying = false;
            ChangeState(e => { e.Enable(); });
        }
    }
}