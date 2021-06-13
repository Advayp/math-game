using Discovery.Minigames.Rhythm;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class QuestionGeneratorTests
    {
        [Test]
        public void Answer_IsCorrect_WhenAnswerIsCalculated()
        {
            StandardQuestionGenerator generator = A.QuestionGenerator.WithNumberOne(2).WithOtherNumber(4);
            var operation = generator.CurrentOperation;
            var expected = DetermineAnswer(2, 4, operation);
            var result = generator.Answer;
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetQuestion_ReturnsTheCorrectString_Given2Numbers()
        {
            StandardQuestionGenerator generator = A.QuestionGenerator.WithNumberOne(2).WithOtherNumber(4);
            var operation = generator.CurrentOperation;
            
            var expected = $"2 {operation} 4";
            var result = generator.GetQuestion();
            
            Assert.AreEqual(expected, result);
        }

        private static int DetermineAnswer(int a, int b, string operation)
        {
            return operation switch
            {
                "x" => a * b,
                "+" => a + b,
                "-" => a - b,
                _ => a / b
            };
        }
    }
}