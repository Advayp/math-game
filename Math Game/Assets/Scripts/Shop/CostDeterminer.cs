namespace MathGame.Shop
{
    public class CostDeterminer : ICostDeterminer
    {
        public int CostForTriesPowerUp(int amount)
        {
            return amount * 20;
        }

        public int CostForTimePowerUp(int amount)
        {
            return amount * 3;
        }

        public int CostForScorePowerUp(int amount)
        {
            return amount * 40;
        }
    }
}