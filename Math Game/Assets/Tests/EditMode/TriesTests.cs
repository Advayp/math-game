using Discovery;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class TriesTests
    {
        [Test]
        public void UseTry_True_IfRemainingTriesIsGreaterThanZero()
        {
            Tries tries = A.Try.WithMax(3);

            var result = tries.UseTry();

            Assert.IsTrue(result);
        }

        [Test]
        public void UseTry_False_IfRemainingTriesIsLessThanZero()
        {
            Tries tries = A.Try.WithMax(1);

            var result = tries.UseTry();

            Assert.IsFalse(result);
        }

        [Test]
        public void RemainingTries_GoesDownByOne_IfUseTrySucceeds()
        {
            Tries tries = A.Try.WithMax(4);

            tries.UseTry();

            Assert.AreEqual(3, tries.RemainingTries);
        }
    }
}