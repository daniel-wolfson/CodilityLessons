using System;

public static class Lesson17
{
    // MaxSumOnBoard: Returns the maximal result that can be achieved on the board represented by array A.
    // Dynamic programming: dp[i] = max sum to reach square i.
    public static int MaxSumOnBoard(int[] A)
    {
        int N = A.Length;
        int[] dp = new int[N];
        dp[0] = A[0];
        for (int i = 1; i < N; i++)
        {
            int maxPrev = dp[i - 1];
            for (int k = 2; k <= 6; k++)
            {
                if (i - k >= 0)
                    maxPrev = Math.Max(maxPrev, dp[i - k]);
            }
            dp[i] = maxPrev + A[i];
        }
        return dp[N - 1];
    }

    // Test for MaxSumOnBoard
    public static void MaxSumOnBoard_Test()
    {
        int[] A = { 1, -2, 0, 9, -1, -2 };
        int result = MaxSumOnBoard(A);
        Console.WriteLine($"MaxSumOnBoard([1,-2,0,9,-1,-2]) = {result} (expected 8)");
    }

    // MinAbsSum: Computes the minimum value of val(A,S) for all possible S in {?1,1}^N.
    // Uses dynamic programming (subset sum variant) to find the closest sum to zero.
    public static int MinAbsSum(int[] A)
    {
        int N = A.Length;
        int sum = 0;
        foreach (var a in A) sum += Math.Abs(a);
        var dp = new bool[sum + 1];
        dp[0] = true;
        foreach (var a in A)
        {
            int absA = Math.Abs(a);
            for (int s = sum; s >= absA; s--)
                if (dp[s - absA]) dp[s] = true;
        }
        int min = sum;
        for (int s = 0; s <= sum; s++)
            if (dp[s]) min = Math.Min(min, Math.Abs(sum - 2 * s));
        return min;
    }

    // Test for MinAbsSum
    public static void MinAbsSum_Test()
    {
        int[] A = { 1, 5, 2, -2 };
        int result = MinAbsSum(A);
        Console.WriteLine($"MinAbsSum([1,5,2,-2]) = {result} (expected 0)");
    }
}
