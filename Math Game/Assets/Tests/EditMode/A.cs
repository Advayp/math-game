namespace Tests.EditMode
{
    public static class A
    {
        public static CounterBuilder Counter => new CounterBuilder();
        public static TriesBuilder Try => new TriesBuilder();
        public static ScorePowerUpBuilder ScorePowerUp => new ScorePowerUpBuilder();
        public static TriesPowerUpBuilder TriesPowerUp => new TriesPowerUpBuilder();
        public static TimerPowerUpBuilder TimerPowerUp => new TimerPowerUpBuilder();
        public static AmmoManagerBuilder AmmoManager => new AmmoManagerBuilder();
    }
}