namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public class StandardChargeDamageCalculator : IChargeDamageCalculator
    {
        public float GetDamage(float time, float maxTime)
        {
            return time / maxTime;
        }
    }
}