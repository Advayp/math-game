namespace Discovery.Shop
{
    public interface ICostDeterminer
    {
        int CostForTriesPowerUp(int amount);

        int CostForTimePowerUp(int amount);

        int CostForScorePowerUp(int amount);
    }
}