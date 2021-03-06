using Discovery.Minigames.FirstPersonShooter.Guns;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class AmmoManagerTests
    {
        [Test]
        public void AmmoCount_Resets_AfterReloading()
        {
            AmmoManager ammoManager = A.AmmoManager.WithMax(5);
            ammoManager.UseBullet();
            ammoManager.StartReloading();
            ammoManager.StopReloading();
            
            Assert.AreEqual(5, ammoManager.CurrentAmmoCount);
        }

        [Test]
        public void UseBullet_False_IfAmmoBeforeIsAtZero()
        {
            AmmoManager ammoManager = A.AmmoManager.WithMax(1);
            ammoManager.UseBullet();
            
            Assert.IsFalse(ammoManager.UseBullet());
        }

        [Test]
        public void AmmoCount_Decreases_IfUseBulletIsCalled()
        {
            AmmoManager manager = A.AmmoManager.WithMax(25);
            manager.UseBullet();
            
            Assert.AreEqual(24, manager.CurrentAmmoCount);
        }
        
        
    }
}