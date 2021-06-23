using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Discovery
{
    public class AnswerChecker : MonoBehaviour, IResetable
    {
        [FormerlySerializedAs("AnswerToCheck")]
        public Answer answerToCheck;

        [FormerlySerializedAs("AnswerButton")]
        public Button answerButton;

        [SerializeField] private AnswerManager manager;

        [FormerlySerializedAs("_image")]
        [SerializeField]
        private Image image;

        public void ChangeImageColor(Color color)
        {
            image.color = color;
            answerButton.interactable = false;
        }

        public void Check()
        {
            manager.Check(this);
        }

        public void Reset()
        {
           ChangeImageColor(Color.white);
           answerButton.interactable = true;    
        }
    }
}