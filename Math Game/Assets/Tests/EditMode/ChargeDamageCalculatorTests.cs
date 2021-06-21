using Discovery.Minigames.FirstPersonShooter.Guns;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class ChargeDamageCalculatorTests
    {
        [Test]
        public void GetDamage_Increases_AsCurrentTimeIncreases()
        {
            StandardChargeDamageCalculator calculator = A.DamageCalculator;

            var damageOne = calculator.GetDamage(1, 2);
            var damageTwo = calculator.GetDamage(0.5f, 2);

            var result = damageOne > damageTwo;
            
            Assert.IsTrue(result);
        }

        [Test]
        public void GetDamage_Decreases_AsCurrentTimeDecreases()
        {
            StandardChargeDamageCalculator calculator = A.DamageCalculator;

            var damageOne = calculator.GetDamage(10, 40);
            var damageTwo = calculator.GetDamage(5, 40);
            
            Assert.IsFalse(damageTwo > damageOne);
        }

        [Test]
        public void GetDamage_IsZero_IfCurrentTimeIsZero()
        {
            StandardChargeDamageCalculator calculator = A.DamageCalculator;

            var damage = calculator.GetDamage(0, 40);

            const int expected = 0;
            
            Assert.AreEqual(expected, damage);
        }
    }
}