namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public interface IChargeDamageCalculator
    {
        float GetDamage(float time, float maxTime);
    }
}