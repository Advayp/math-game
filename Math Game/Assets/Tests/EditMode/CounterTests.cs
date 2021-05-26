using NUnit.Framework;
using MathGame.Managers;

public class CounterTests
{
	[Test]
	public void Counter_DoesNotIncrement_IfCountIsAtMax()
	{
		MaxInclusiveCounter counter = A.Counter.WithStartValue(10).WithMaxValue(10);

		counter.Increment();

		Assert.AreEqual(10, counter.Count);
	}

	[Test]
	public void Counter_SetsCountToMax_IfCountIsPastMax()
	{
		MaxInclusiveCounter counter = A.Counter.WithStartValue(12).WithMaxValue(10);

		counter.Increment();

		Assert.AreEqual(10, counter.Count);
	}

	[Test]
	public void HasReachedMax_True_IfCountGreaterThanMax()
	{
		MaxInclusiveCounter counter = A.Counter.WithStartValue(10).WithMaxValue(10);

		counter.Increment();

		Assert.AreEqual(true, counter.HasReachedMax);
	}

	[Test]
	public void HasReachedMax_False_IfCountIsNotAtMax()
	{
		MaxInclusiveCounter counter = A.Counter.WithStartValue(1).WithMaxValue(10);

		counter.Increment();

		Assert.AreEqual(false, counter.HasReachedMax);
	}

	[Test]
	public void Counter_IncrementsCount_IfCountIsNotPastMax()
	{
		MaxInclusiveCounter counter = A.Counter.WithStartValue(1).WithMaxValue(10);

		counter.Increment();

		Assert.AreEqual(2, counter.Count);
	}
}