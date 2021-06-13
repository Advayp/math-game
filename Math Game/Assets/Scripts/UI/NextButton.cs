using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery.UI
{
    public class NextButton : MonoBehaviour
    {
        [FormerlySerializedAs("_nextButton")]
        [SerializeField]
        private GameObject nextButton;

        private void Start()
        {
            nextButton.SetActive(false);
            AnswerManager.QuestionCompleted += SetNextButtonToActive;
        }

        private void OnDestroy()
        {
            AnswerManager.QuestionCompleted -= SetNextButtonToActive;
        }

        private void SetNextButtonToActive()
        {
            nextButton.SetActive(true);
        }
    }
}