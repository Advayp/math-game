using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery
{
    public class QuestionDisplayer : MonoBehaviour
    {
        [FormerlySerializedAs("_label")] [SerializeField, Header("Dependencies"), Space]
        protected TMP_Text label;

        [FormerlySerializedAs("_question")] [SerializeField, Header("Config"), Space]
        protected Question question;


        protected virtual void Awake()
        {
           label.Require(this);
        }

        protected virtual void Start()
        {
            Initialize(question);
        }

        public virtual void Initialize(Question desiredQuestion)
        {
            print($"Changed Text to {desiredQuestion.text}");
            question = desiredQuestion;
            label.SetText(question.text);
        }
    }
}