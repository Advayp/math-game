using Discovery;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class DecreasingCounterTests
    {
        [Test]
        public void Increment_IncreasesCountByOne_IfCountIsNotAtMax()
        {
            StandardDecreasingCounter counter = A.DecreasingCounter.WithCurrentCount(0).WithMaxCount(10).WithMinCount(0);

            counter.Increment();

            Assert.AreEqual(1, counter.Count);
        }

        [Test]
        public void HasReachedMax_True_IfCountIsAtMax()
        {
            StandardDecreasingCounter counter = A.DecreasingCounter.WithCurrentCount(9).WithMaxCount(10);

            counter.Increment();

            Assert.IsTrue(counter.HasReachedMax);
            Assert.IsFalse(counter.HasReachedMin);
        }

        [Test]
        public void HasReachedMax_False_IfCountIsNotAtMax()
        {
            StandardDecreasingCounter counter = A.DecreasingCounter.WithCurrentCount(1).WithMaxCount(10);
            
            counter.Increment();
            
            Assert.IsFalse(counter.HasReachedMax);
        }

        [Test]
        public void HasReachedMin_True_IfCountIsAtMin()
        {
            StandardDecreasingCounter counter = A.DecreasingCounter.WithCurrentCount(1).WithMaxCount(10);
            
            counter.Decrement();
            
            Assert.IsTrue(counter.HasReachedMin);
            Assert.IsFalse(counter.HasReachedMax);
        }

        [Test]
        public void HasReachedMax_False_IfCountWasAtMaxButNowIsNot()
        {
            StandardDecreasingCounter counter = A.DecreasingCounter.WithCurrentCount(9).WithMaxCount(10);
            
            counter.Increment();
            
            counter.Decrement();
            counter.Decrement();
            
            Assert.IsFalse(counter.HasReachedMax);
            Assert.IsFalse(counter.HasReachedMin);
        }

        [Test]
        public void HasReachedMin_False_IfCountWasAtMinButNowIsNot()
        {
            StandardDecreasingCounter counter = A.DecreasingCounter.WithCurrentCount(1).WithMaxCount(10);
            
            counter.Decrement();
            
            counter.Increment();
            
            Assert.IsFalse(counter.HasReachedMin);
            Assert.IsFalse(counter.HasReachedMax);
        }

        [Test]
        public void Decrement_DecreasesCountByOne_IfCountIsNotAtMin()
        {
            StandardDecreasingCounter counter = A.DecreasingCounter.WithCurrentCount(5).WithMaxCount(10);
            
            counter.Decrement();
            
            Assert.AreEqual(4, counter.Count);
        }
    }
}