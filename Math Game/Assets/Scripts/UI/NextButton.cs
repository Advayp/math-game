using UnityEngine;
using UnityEngine.UI;

namespace Discovery.UI
{
    public class NextButton : MonoBehaviour
    {
        [SerializeField] private Button nextButton;

        private void Start()
        {
            nextButton.interactable = false;
            AnswerManager.QuestionCompleted += SetNextButtonToActive;
        }

        private void OnDestroy()
        {
            AnswerManager.QuestionCompleted -= SetNextButtonToActive;
        }

        private void SetNextButtonToActive()
        {
            nextButton.interactable = true; 
        }
    }
}