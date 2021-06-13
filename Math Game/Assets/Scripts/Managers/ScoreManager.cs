using UnityEngine;

namespace Discovery.Managers
{
    public class ScoreManager : MonoBehaviour, IManageScore
    {
        [SerializeField] private Question mainQuestion;
        [SerializeField] private FloatVariable score;

        public FloatVariable Score => score;

        private int _pointsAddedToScore;

        private void Awake()
        {
           mainQuestion.Require(this);
           score.Require(this);
        }

        private void Start()
        {
            _pointsAddedToScore = mainQuestion.pointsRewarded;
        }

        public void IncreaseScore()
        {
            print("Increased Score");
            Score.value += _pointsAddedToScore;
        }

        public void LowerScore()
        {
            Score.value = Mathf.Clamp(Score.value - _pointsAddedToScore, 0, int.MaxValue);
        }

        public void UseScorePowerUp()
        {
            PowerUpManager.UseScore(ref _pointsAddedToScore);
        }
        
    }
}