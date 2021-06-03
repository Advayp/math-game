using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace MathGame.Display
{
    public class AnswerDisplayer : MonoBehaviour
    {
        [FormerlySerializedAs("_label")]
        [SerializeField] private TMP_Text label;

        [FormerlySerializedAs("_answer")]
        [SerializeField] private Answer answer;

        private void Start()
        {
            label.SetText(answer.value);
        }
    }
}