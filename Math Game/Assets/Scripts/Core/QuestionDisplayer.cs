using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery
{
    public class QuestionDisplayer : MonoBehaviour
    {
        [FormerlySerializedAs("_label")] [SerializeField]
        private TMP_Text label;

        [FormerlySerializedAs("_question")] [SerializeField]
        private Question question;

        private void Awake()
        {
           label.Require(this);
        }

        private void Start()
        {
            Initialize(question);
        }

        private void Initialize(Question desiredQuestion)
        {
            question = desiredQuestion;
            label.SetText(question.text);
        }
    }
}