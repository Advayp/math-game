using Discovery.Minigames.FirstPersonShooter.Guns;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class ReloadCalculatorTests
    {
        [Test]
        public void CalculatedAmount_Is_GreaterThan_AmountForSmaller_Ammo()
        {
            MultipleOfTenReloadTimeCalculator calculator = A.ReloadCalculator;
            
            Assert.IsTrue(calculator.Calculate(200) > calculator.Calculate(100));
        }

        [Test]
        public void CalculatedAmount_IsZero_IfTheAmmoIsZero()
        {
            MultipleOfTenReloadTimeCalculator calculator = A.ReloadCalculator;

            const int expected = 0;
            var result = calculator.Calculate(0);
            
            Assert.AreEqual(expected, result);
        }
    }
}