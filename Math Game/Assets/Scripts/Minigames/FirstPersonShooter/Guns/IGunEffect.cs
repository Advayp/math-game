namespace Discovery.Minigames.FirstPersonShooter.Guns
{
    public interface IGunEffect
    {
        void OnReloadStart();
        void OnReloadStop();
        void OnShoot();
    }
}