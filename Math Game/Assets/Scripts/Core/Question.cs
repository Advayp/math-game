using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MathGame
{
    [CreateAssetMenu]
    public class Question : ScriptableObject
    {
        [FormerlySerializedAs("Text")]
        public string text;

        [FormerlySerializedAs("PointsRewarded")]
        public int pointsRewarded;

        [FormerlySerializedAs("Tries")]
        public int tries;

        [FormerlySerializedAs("Seconds")]
        public int seconds;

        [FormerlySerializedAs("CorrectAnswer")]
        public Answer correctAnswer;

        [FormerlySerializedAs("WrongAnswers")]
        public List<Answer> wrongAnswers;
    }
}