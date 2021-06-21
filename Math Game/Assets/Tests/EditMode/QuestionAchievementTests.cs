using Discovery.Achievements;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class QuestionAchievementTests
    {
        [Test]
        public void Check_True_IfValueIsInBetweenMilestones()
        {
            
            QuestionAchievementHandler handler = A.QuestionAchievement.WithMilestones(1, 3);

            var result = handler.Check(1);

            Assert.IsTrue(result);
        }

        [Test]
        public void Check_False_IfValueIsNotBetweenMilestones()
        {
            QuestionAchievementHandler handler = A.QuestionAchievement.WithMilestones(20, 40, 100);

            var result = handler.Check(1);
            
            Assert.IsFalse(result);
        }

        [Test]
        public void Check_True_IfValueIsAtMaxOfMilestoneRange()
        {
            QuestionAchievementHandler handler = A.QuestionAchievement.WithMilestones(1, 10, 20);

            var result = handler.Check(10);
            
            Assert.IsTrue(result);
        }

        [Test]
        public void GetString_ReturnsAppropriateString_IfValueIsBetweenMilestones()
        {
            QuestionAchievementHandler handler = A.QuestionAchievement.WithMilestones(1, 10, 40);

            handler.Check(5);

            const string expected = "Answered 1 question(s)!";
            var result = handler.GetText();
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxTest()
        {
            QuestionAchievementHandler handler = A.QuestionAchievement.WithMilestones(1, 10, 40, 50);

            handler.Check(100);

            const string expected = "Answered 50 question(s)!";
            var result = handler.GetText();
            
            Assert.AreEqual(expected, result);
        }
    }
}