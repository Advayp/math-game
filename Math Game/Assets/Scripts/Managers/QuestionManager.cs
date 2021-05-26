using System.Collections.Generic;
using UnityEngine;

namespace MathGame.Managers
{
    public class QuestionManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _questionGameObjects;
        [SerializeField] private GameObject _nextButton;

        private ICounter _counter;

        private void Start()
        {
            _counter = new MaxInclusiveCounter(0, _questionGameObjects.Count - 1);
            _questionGameObjects[_counter.Count].SetActive(true);
        }

        // Used in Unity
        public void LoadNextQuestion()
        {
            _questionGameObjects[_counter.Count].SetActive(false);
            _counter.Increment();
            if (_counter.HasReachedMax)
            {
                // Start new Question Set
                return;
            }
            _questionGameObjects[_counter.Count].SetActive(true);
            _nextButton.SetActive(false);
        }
    }
}