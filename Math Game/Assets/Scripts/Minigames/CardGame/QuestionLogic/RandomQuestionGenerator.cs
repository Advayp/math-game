using System;

namespace Discovery.Minigames.CardGame.QuestionLogic
{
    public class RandomQuestionGenerator
    {
        private readonly Random _random;
        private readonly int _min;
        private readonly int _max;

        public int Answer { get; private set; } = -1;

        public RandomQuestionGenerator(int min, int max)
        {
            _min = min;
            _max = max;
            _random = new Random();
        }

        public void GetRandomNumbers(out int numberOne, out int numberTwo)
        {
            numberOne = _random.Next(_min, _max);
            numberTwo = _random.Next(_min, _max);

            Answer = numberOne + numberTwo;
        }
        
    }
}