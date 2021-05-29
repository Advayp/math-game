using MathGame.Core;
using UnityEngine;

namespace MathGame.Managers
{
    public class ScoreManager : MonoBehaviour, IManageScore
    {
        [SerializeField] private Question mainQuestion;
        [SerializeField] private FloatVariable score;

        public FloatVariable Score
        {
            get => score;
            set => score = value;
        }

        public void IncreaseScore()
        {
            print("Increased Score");
            Score.value += mainQuestion.pointsRewarded;
        }

        public void LowerScore()
        {
            Score.value = Mathf.Clamp(Score.value - mainQuestion.pointsRewarded, 0, int.MaxValue);
        }
        
    }
}