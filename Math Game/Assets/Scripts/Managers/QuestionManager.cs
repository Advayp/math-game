using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MathGame.Managers
{
    public class QuestionManager : MonoBehaviour
    {
        [FormerlySerializedAs("_questionGameObjects")]
        [SerializeField] private List<GameObject> questionGameObjects;

        [FormerlySerializedAs("_nextButton")]
        [SerializeField] private GameObject nextButton;

        private ICounter _counter;

        private void Start()
        {
            _counter = new MaxInclusiveCounter(0, questionGameObjects.Count - 1);
            questionGameObjects[_counter.Count].SetActive(true);
        }

        public void LoadNextQuestion()
        {
            questionGameObjects[_counter.Count].SetActive(false);
            _counter.Increment();
            if (_counter.HasReachedMax)
            {
                // Start new Question Set
                return;
            }
            questionGameObjects[_counter.Count].SetActive(true);
            nextButton.SetActive(false);
        }
        
    }
}