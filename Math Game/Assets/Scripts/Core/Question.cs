using UnityEngine;
using UnityEngine.Serialization;

namespace Discovery
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
    }
}