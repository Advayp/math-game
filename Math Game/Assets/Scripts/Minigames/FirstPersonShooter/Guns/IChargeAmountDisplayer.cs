namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public interface IChargeAmountDisplayer
    {
        void Initialize(float maxValue);
        void HandleTime(float currentValue);
        void Hide();
        void Show();
    }
}