using MathGame;

namespace Tests.EditMode
{
    public class TriesBuilder
    {
        private int _maxTries;

        public TriesBuilder WithMax(int maxTries)
        {
            _maxTries = maxTries;
            return this;
        }

        private Tries Build()
        {
            return new Tries(_maxTries);
        }

        public static implicit operator Tries(TriesBuilder builder)
        {
            return builder.Build();
        }
    }
}