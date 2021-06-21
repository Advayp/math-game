using System;
using UnityEngine;

namespace Discovery.Achievements
{
    public class AchievementManager : MonoBehaviour
    {
        [SerializeField] private Achievements achievements;
        [SerializeField] private FloatVariable score;
        
        public event Action UpdatedQuestionAchievements, UpdatedScoreAchievements;

        private void Awake()
        {
           achievements.Require(this); 
           score.Require(this);
        }
        

        private void OnEnable()
        {
            AnswerManager.QuestionCompleted += UpdateQuestionCount;
            AnswerManager.Scored += UpdateScoreCount;
        }

        private void OnDisable()
        {
            AnswerManager.QuestionCompleted -= UpdateQuestionCount;
            AnswerManager.Scored -= UpdateScoreCount;
        }

        private void UpdateQuestionCount()
        {
            achievements.questionsAnswered++;
            OnAchieved();
        }

        private void UpdateScoreCount()
        {
            achievements.score = Mathf.Max(achievements.score, score.value);
            OnUpdatedScoreAchievements();
        }

        private void OnAchieved()
        {
            UpdatedQuestionAchievements?.Invoke();
        }

        private void OnUpdatedScoreAchievements()
        {
            UpdatedScoreAchievements?.Invoke();
        }
    }
}