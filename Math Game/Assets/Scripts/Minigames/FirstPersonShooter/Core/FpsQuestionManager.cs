using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Discovery.Minigames.FirstPersonShooter
{
    public class FpsQuestionManager : MonoBehaviour
    {
        [SerializeField] private QuestionDisplayer questionDisplay;
        [SerializeField] private Question[] questions;
        [SerializeField] private GameObject[] objectsToDisable;

        [SerializeField, Tooltip("The delay before the question that is currently displaying disappears.")]
        private float delay = 0.3f;

        public static bool IsQuestionDisplaying;

        private readonly List<IEnableable[]> _enableables = new List<IEnableable[]>();

        private WaitForSeconds _hideQuestionDelay;


        private void Awake()
        {
            foreach (var objectToDisable in objectsToDisable)
            {
                _enableables.Add(objectToDisable.GetComponents<IEnableable>());
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
            var randomIndex = random.Next(questions.Length);
            var randomQuestion = questions[randomIndex];

            questionDisplay.Initialize(randomQuestion);

            questionDisplay.Show();
            IsQuestionDisplaying = true;
            DisableAll();
        }

        private void DisableAll()
        {
            foreach (var enableable in _enableables.SelectMany(e => e))
            {
                enableable.Disable();
            }
        }

        private void EnableAll()
        {
            foreach (var enableable in _enableables.SelectMany(e => e))
            {
                enableable.Enable();
            }
        }


        public void HideQuestion()
        {
            StartCoroutine(HideQuestionCoroutine());
        }

        private IEnumerator HideQuestionCoroutine()
        {
            yield return _hideQuestionDelay;
            questionDisplay.Hide();
            IsQuestionDisplaying = false;
            EnableAll();
        }
    }
}