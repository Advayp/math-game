using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace MathGame.Display
{
	public class QuestionDisplayer : MonoBehaviour
	{
		[FormerlySerializedAs("_label")]
		[SerializeField] private TMP_Text label;
		[FormerlySerializedAs("_question")]
		[SerializeField] private Question question;

		private void Start()
		{
			label.SetText(question.text);
		}
	}
}