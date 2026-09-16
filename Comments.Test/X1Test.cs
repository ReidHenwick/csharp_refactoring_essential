namespace Comments.Test;

using NUnit.Framework;

[TestFixture]
public class X1Test
{
    [Test]
    public void CalculatingSumOfSquaresGivenRangeCalculatesSumOfSquares()
    {
        int calculateExpectedSumOfSquares(int startRange, int endRange)
        {
            int expectedSumOfSquares = 0;
            for (int i = startRange; i <= endRange; i++)
            {
                expectedSumOfSquares += i * i;
            }

            return expectedSumOfSquares;
        }

        int startRange = 7;
        int endRange = 12;

        var expectedSumOfSquares = calculateExpectedSumOfSquares(
            startRange,
            endRange);

        int actualSumOfSquares = X1.M(startRange, endRange);

        Assert.That(
            actualSumOfSquares,
            Is.EqualTo(expectedSumOfSquares));
    }
}