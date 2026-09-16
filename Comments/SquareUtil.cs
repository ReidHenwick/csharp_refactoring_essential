namespace Comments;

public static class SquareUtil
{
    public static int SumOfSquares(int startRange, int endRange)
    {
        var runningTotal = 0;

        for (var i = startRange; i <= endRange; i++)
        {
            runningTotal += CalculateSquare(i);
        }

        return runningTotal;
    }

    private static int CalculateSquare(int input)
    {
        return input * input;
    }
}