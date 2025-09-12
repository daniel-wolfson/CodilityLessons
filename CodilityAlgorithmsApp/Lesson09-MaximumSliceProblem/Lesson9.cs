public static class Lesson9
{
    // MaxProfit: Returns the maximum possible profit from one transaction during the period.
    // If no profit is possible, returns 0.
    // Uses a single pass to track the minimum price and maximum profit.
    public static int MaxProfit(int[] A)
    {
        int minPrice = int.MaxValue;
        int maxProfit = 0;
        foreach (var price in A)
        {
            if (price < minPrice)
                minPrice = price;
            else if (price - minPrice > maxProfit)
                maxProfit = price - minPrice;
        }
        return maxProfit;
    }

    // Test for MaxProfit
    public static void MaxProfit_Test()
    {
        int[] A = { 23171, 21011, 21123, 21366, 21013, 21367 };
        int result = MaxProfit(A);
        Console.WriteLine($"MaxProfit([23171,21011,21123,21366,21013,21367]) = {result} (expected 356)");
    }

    // MaxSliceSum: Returns the maximum sum of any slice of A (Kadane's algorithm).
    public static int MaxSliceSum(int[] A)
    {
        int maxEnding = A[0];
        int maxSlice = A[0];
        for (int i = 1; i < A.Length; i++)
        {
            maxEnding = Math.Max(A[i], maxEnding + A[i]);
            maxSlice = Math.Max(maxSlice, maxEnding);
        }
        return maxSlice;
    }

    // Test for MaxSliceSum
    public static void MaxSliceSum_Test()
    {
        int[] A = { 3, 2, -6, 4, 0 };
        int result = MaxSliceSum(A);
        Console.WriteLine($"MaxSliceSum([3,2,-6,4,0]) = {result} (expected 5)");
    }

    // MaxDoubleSliceSum: Returns the maximal sum of any double slice.
    // Uses prefix and suffix sums to efficiently compute the result.
    public static int MaxDoubleSliceSum(int[] A)
    {
        int N = A.Length;
        int[] maxEndingHere = new int[N];
        int[] maxStartingHere = new int[N];
        for (int i = 1; i < N - 1; i++)
            maxEndingHere[i] = Math.Max(0, maxEndingHere[i - 1] + A[i]);
        for (int i = N - 2; i > 0; i--)
            maxStartingHere[i] = Math.Max(0, maxStartingHere[i + 1] + A[i]);
        int maxDoubleSlice = 0;
        for (int i = 1; i < N - 1; i++)
            maxDoubleSlice = Math.Max(maxDoubleSlice, maxEndingHere[i - 1] + maxStartingHere[i + 1]);
        return maxDoubleSlice;
    }

    // Test for MaxDoubleSliceSum
    public static void MaxDoubleSliceSum_Test()
    {
        int[] A = { 3, 2, 6, -1, 4, 5, -1, 2 };
        int result = MaxDoubleSliceSum(A);
        Console.WriteLine($"MaxDoubleSliceSum([3,2,6,-1,4,5,-1,2]) = {result} (expected 17)");
    }
}
