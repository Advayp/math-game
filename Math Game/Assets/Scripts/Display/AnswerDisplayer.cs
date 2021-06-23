using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery.Display
{
    public class AnswerDisplayer : MonoBehaviour
    {
        [FormerlySerializedAs("_label")]
        [SerializeField]
        private TMP_Text label;

        [FormerlySerializedAs("_answer")]
        [SerializeField]
        private Answer answer;

        private void Start()
        {
            label.SetText(answer.value);
        }

        public void Initialize(Answer answerToUse)
        {
            answer = answerToUse;
            label.SetText(answer.value);
        }   
        
    }
}