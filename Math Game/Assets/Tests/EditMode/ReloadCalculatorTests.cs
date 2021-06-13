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
    }
}