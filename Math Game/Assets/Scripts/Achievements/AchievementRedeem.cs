using UnityEngine;

namespace Discovery.Achievements
{
    public class AchievementRedeem : MonoBehaviour
    {
        [SerializeField, Header("Dependencies"), Space] private Achievements achievement;
        [SerializeField] private AchievementManager manager;
        [SerializeField] private GameObject achievementDisplay;

        [SerializeField, Header("Config"), Space] private bool resetAchievements;

        private IAchievementHandler[] _achievementHandlers;
        private IAchievementDisplay _achievementDisplay;

        private void Awake()
        {
           achievement.Require(this); 
           manager.Require(this);
           
           achievementDisplay.RequireComponent<IAchievementDisplay>(this);
           _achievementDisplay = achievementDisplay.GetComponent<IAchievementDisplay>();
        }

        private void Start()
        {
            if (resetAchievements)
            {
                achievement.Reset();
            } 
            
            InitializeAchievements();
        }

        private void OnEnable()
        {
            manager.UpdatedQuestionAchievements += CheckForQuestionAchievement;
            manager.UpdatedScoreAchievements += CheckForScoreAchievement;
        }

        private void OnDisable()
        {
            manager.UpdatedQuestionAchievements -= CheckForQuestionAchievement;
            manager.UpdatedScoreAchievements -= CheckForScoreAchievement;
        }

        private void CheckForQuestionAchievement()
        {
            foreach (var achievementHandler in _achievementHandlers)
            {
                if (achievementHandler.Type == AchievementType.Score) continue;
                if (!achievementHandler.Check(achievement)) continue;
               HandleAchieved(achievementHandler); 
            }
        }

        private void CheckForScoreAchievement()
        {
            foreach (var achievementHandler in _achievementHandlers)
            {
                if (achievementHandler.Type == AchievementType.Question) continue;
                if (!achievementHandler.Check(achievement)) continue;
               HandleAchieved(achievementHandler); 
            }

        }

        private void HandleAchieved(IAchievementHandler handler)
        {
            var text = handler.GetText();
            print(text);
            
            achievement.AddText(text);
            
            _achievementDisplay.Initialize(text);
            _achievementDisplay.Display();
        }

        private void InitializeAchievements()
        {
            _achievementHandlers = new IAchievementHandler[]
            {
                new QuestionAchievementHandler(1, 10, 40, 50),
                new ScoreAchievementHandler(1, 10, 40, 50)
            };
        }
    }
}