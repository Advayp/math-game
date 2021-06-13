using Discovery.Minigames.Rhythm;

namespace Tests.EditMode
{
    public class StandardQuestionGeneratorBuilder
    {
        private int _numberOne, _numberTwo;

        public StandardQuestionGeneratorBuilder WithNumberOne(int numberOne)
        {
            _numberOne = numberOne;
            return this;
        }

        public StandardQuestionGeneratorBuilder WithOtherNumber(int numberTwo)
        {
            _numberTwo = numberTwo;
            return this;
        }

        private StandardQuestionGenerator Build()
        {
            return new StandardQuestionGenerator(_numberOne, _numberTwo);
        }

        public static implicit operator StandardQuestionGenerator(StandardQuestionGeneratorBuilder builder)
        {
            return builder.Build();
        }
    }
}