using Discovery.Achievements;

namespace Tests.EditMode
{
    public class QuestionAchievementBuilder
    {
        private int[] _milestones = { };
        
        public QuestionAchievementBuilder WithMilestones(params int[] milestones)
        {
            _milestones = milestones;
            return this;
        }

        private QuestionAchievementHandler Build()
        {
            return new QuestionAchievementHandler(_milestones);
        }

        public static implicit operator QuestionAchievementHandler(QuestionAchievementBuilder builder)
        {
            return builder.Build();
        }
    }
}