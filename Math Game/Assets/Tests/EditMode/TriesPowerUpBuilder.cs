using Discovery.PowerUps;

namespace Tests.EditMode
{
    public class TriesPowerUpBuilder
    {
        private int _triesToAdd;

        public TriesPowerUpBuilder WithAddedValue(int amount)
        {
            _triesToAdd = amount;
            return this;
        }

        private TriesPowerUp Build()
        {
            return new TriesPowerUp(_triesToAdd);
        }

        public static implicit operator TriesPowerUp(TriesPowerUpBuilder builder)
        {
            return builder.Build();
        }
    }
}