using System.Collections.Generic;
using System.Linq;

namespace Discovery.Achievements
{
    public class ScoreAchievementHandler : IAchievementHandler
    {
        private readonly List<int> _milestones;
        private string _achievementText = "";

        public AchievementType Type => AchievementType.Score;

        public ScoreAchievementHandler(params int[] milestones)
        {
            _milestones = milestones.ToList();
        }

        private bool Check(int value)
        {
            foreach (var i in _milestones.OrderByDescending(e => e))
            {
                if (value < i) continue;
                _achievementText = $"Achieved a Score of {i}";
                _milestones.Remove(i);
                RemovePrevious(i);
                return true;
            }

            return false;
        }

        private void RemovePrevious(int current)
        {
            var newMilestones = _milestones.ToList();
            foreach (var newMilestone in newMilestones.Where(newMilestone => newMilestone < current))
            {
                _milestones.Remove(newMilestone);
            }
        }

        public bool Check(Achievements achievement)
        {
            return Check(achievement.score);
        }

        public string GetText() => _achievementText;

    }
}