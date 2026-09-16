namespace Comments.Test;

using NUnit.Framework;

[TestFixture]
public class X1Test
{
    [Test]
    public void T1()
    {
        int startRange = 7;
        int endRange = 12;

        // Expected: sum of squares from 7 to 12
        int expectedSumOfSquares = 0;
        for (int i = startRange; i <= endRange; i++)
        {
            expectedSumOfSquares += i * i;
        }

        int actualSumOfSquares = X1.M(startRange, endRange);

        Assert.That(actualSumOfSquares, Is.EqualTo(expectedSumOfSquares));
    }
}