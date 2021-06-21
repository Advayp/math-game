using System.Collections.Generic;
using System.Linq;

namespace Discovery.Achievements
{
    public class QuestionAchievementHandler : IAchievementHandler
    {
        private readonly List<int> _milestones;
        private string _achievementText = "";

        public AchievementType Type => AchievementType.Question;
        
        public QuestionAchievementHandler(params int[] milestones)
        {
            _milestones = milestones.ToList();
        }

        public bool Check(int value)
        {

            foreach (var i in _milestones.OrderByDescending(e => e))
            {
                if (value < i) continue;
                _achievementText = $"Completed {i} questions!";
                _milestones.Remove(i);
                return true;
            }

            return false;

        }

        public bool Check(Achievements achievements)
        {
            var value = achievements.questionsAnswered;

            return Check(value);
        }

        public string GetText()
        {
            return _achievementText;
        }
    }
}