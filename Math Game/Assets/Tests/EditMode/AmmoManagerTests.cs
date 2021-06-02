using MathGame.Minigames.FirstPersonShooter.Guns;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class AmmoManagerTests
    {
        [Test]
        public void IsReloading_True_IfStartReloadIsCalled()
        {
            AmmoManager ammoManager = A.AmmoManager.WithMaxCount(1);
            
            ammoManager.StartReloading();
            
            Assert.IsTrue(ammoManager.IsReloading);
        }

        [Test]
        public void IsReloading_False_IfStopReloadIsCalled()
        {
            AmmoManager ammoManager = A.AmmoManager.WithMaxCount(1);
            
            ammoManager.StartReloading();
            
            ammoManager.StopReloading();
            
            Assert.IsFalse(ammoManager.IsReloading);
        }
    }
}