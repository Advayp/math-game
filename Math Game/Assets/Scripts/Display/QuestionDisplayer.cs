using UnityEngine;
using TMPro;
using MathGame.Core;

namespace MathGame.Display
{
	public class QuestionDisplayer : MonoBehaviour
	{
		[SerializeField] private TMP_Text _label;
		[SerializeField] private Question _question;

		private void Start()
		{
			_label.SetText(_question.Text);
		}
	}
}