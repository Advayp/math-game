using MathGame.Core;

public class TriesBuilder
{
    private int _maxTries;

    public TriesBuilder WithMax(int maxTries)
    {
        _maxTries = maxTries;
        return this;
    }

    public Tries Build()
    {
        return new Tries(_maxTries);
    }

    public static implicit operator Tries(TriesBuilder builder)
    {
        return builder.Build();
    }
}