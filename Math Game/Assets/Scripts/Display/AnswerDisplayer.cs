using UnityEngine;
using TMPro;
using MathGame.Core;

namespace MathGame.Display
{
	public class AnswerDisplayer : MonoBehaviour
	{
		[SerializeField] private TMP_Text _label;
		[SerializeField] private Answer _answer;

		private void Start()
		{
			_label.SetText(_answer.value);
		}
	}
}