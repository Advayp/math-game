using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MathGame.Core
{
    public class AnswerChecker : MonoBehaviour
    {
        [FormerlySerializedAs("AnswerToCheck")]
        public Answer answerToCheck;

        [FormerlySerializedAs("AnswerButton")]
        public Button answerButton;

        [FormerlySerializedAs("_image")]
        [SerializeField] private Image image;

        public void ChangeImageColor(Color color)
        {
            image.color = color;
            answerButton.interactable = false;
        }
    }
}