using System;

namespace MathGame.PowerUps
{
    [Serializable]
    public class TriesPowerUp : IPowerUp<int>
    {
        private readonly int _triesAdded;

        public TriesPowerUp(int triesAdded)
        {
            _triesAdded = triesAdded;
        }

        public void Use(ref int amount)
        {
            amount += _triesAdded;
        }
    }
}