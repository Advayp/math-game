using UnityEngine;
using UnityEngine.UI;

namespace MathGame.Core
{
	public class AnswerChecker : MonoBehaviour
	{
		public Answer AnswerToCheck;
		public Button AnswerButton;
		[SerializeField] private Image _image;

		public void ChangeImageColor(Color color)
		{
			_image.color = color;
		}
	}
}