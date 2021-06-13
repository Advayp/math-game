using Discovery.PowerUps;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class PowerUpTests
    {
        [Test]
        public void Score_Increases_IfIncrementIsCalled()
        {
            var amount = 1;
            ScorePowerUp scorePowerUp = A.ScorePowerUp.WithAddedValue(20);
            
            scorePowerUp.Use(ref amount);
            
            Assert.AreEqual(20, amount);
        }

        [Test]
        public void Tries_Increases_IfIncrementIsCalled()
        {
            var amount = 0;
            TriesPowerUp triesPowerUp = A.TriesPowerUp.WithAddedValue(20);
            
            triesPowerUp.Use(ref amount);
            
            Assert.AreEqual(20, amount);
        }

        [Test]
        public void Timer_Increases_IfIncrementIsCalled()
        {
            var amount = 0f;
            TimePowerUp timePowerUp = A.TimerPowerUp.WithAddedValue(20);
            
            timePowerUp.Use(ref amount);
            
            Assert.AreEqual(20, amount);
        }
    }
}