using System.Collections.Generic;
using UnityEngine;

namespace MathGame.Core
{
	[CreateAssetMenu]
	public class Question : ScriptableObject
	{
		public string Text;
		public int PointsRewarded;
		public Answer CorrectAnswer;
		public List<Answer> WrongAnswers;
	}
}