using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery
{
    public class QuestionDisplayer : MonoBehaviour
    {
        [FormerlySerializedAs("_label")] [SerializeField, Header("Dependencies"), Space]
        private TMP_Text label;

        [FormerlySerializedAs("_question")] [SerializeField, Header("Config"), Space]
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
            label.SetText(question.text.Color(AvailableColors.HeaderColor));
        }
    }
}