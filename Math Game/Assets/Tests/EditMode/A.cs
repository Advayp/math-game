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
        public static ReloadCalculatorBuilder ReloadCalculator => new ReloadCalculatorBuilder();
        public static StandardQuestionGeneratorBuilder QuestionGenerator => new StandardQuestionGeneratorBuilder();
        public static ChargeDamageCalculatorBuilder DamageCalculator => new ChargeDamageCalculatorBuilder();
        public static QuestionAchievementBuilder QuestionAchievement => new QuestionAchievementBuilder();
        public static DecreasingCounterBuilder DecreasingCounter => new DecreasingCounterBuilder();
    }
}