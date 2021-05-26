using UnityEngine;
using MathGame.Core;

namespace MathGame.UI
{
	public class NextButton : MonoBehaviour
	{
		[SerializeField] private GameObject _nextButton;

		private void Start()
		{
			_nextButton.SetActive(false);
			AnswerManager.Scored += SetNextButtonToActive;
		}

		private void OnDestroy()
		{
			AnswerManager.Scored -= SetNextButtonToActive;
		}

		public void SetNextButtonToActive()
		{
			_nextButton.SetActive(true);
		}
	}
}