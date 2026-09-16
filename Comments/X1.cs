namespace Comments;

public class X1
{
    public static int M(int startRange, int endRange)
    {
        int runningTotal = 0;

        // Iterate from lower bound (startRange) to upper bound (endRange)
        for (int i = startRange; i <= endRange; i++)
        {
            // Add square of each number in the range
            runningTotal += CalculateSquare(i);
        }

        return runningTotal;
    }

    static int CalculateSquare(int input)
    {
        return input * input;
    }
}