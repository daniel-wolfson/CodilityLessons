public static class Leson5
{
    // PassingCars: Counts the number of pairs of passing cars (east to west)
    // 0 = east, 1 = west. For each 0, count the number of 1s to its right.
    // Returns -1 if the number of pairs exceeds 1,000,000,000.
    public static int PassingCars(int[] A)
    {
        int eastCars = 0;
        int pairs = 0;
        foreach (var car in A)
        {
            if (car == 0)
            {
                eastCars++;
            }
            else // car == 1
            {
                pairs += eastCars;
                if (pairs > 1000000000)
                    return -1;
            }
        }
        return pairs;
    }

    // Test for PassingCars
    public static void PassingCars_Test()
    {
        int[] A = { 0, 1, 0, 1, 1 };
        int result = PassingCars(A);
        Console.WriteLine($"PassingCars([0,1,0,1,1]) = {result} (expected 5)");
    }

    // CountDiv: Returns the number of integers within [A..B] divisible by K
    public static int CountDiv(int A, int B, int K)
    {
        int first = (A % K == 0) ? 1 : 0;
        return (B / K) - (A / K) + first;
    }

    // Test for CountDiv
    public static void CountDiv_Test()
    {
        int result = CountDiv(6, 11, 2);
        Console.WriteLine($"CountDiv(6, 11, 2) = {result} (expected 3)");
    }

    // GenomicRangeQuery: For each query, returns the minimal impact factor in the substring S[P[K]..Q[K]]
    // A=1, C=2, G=3, T=4
    public static int[] GenomicRangeQuery(string S, int[] P, int[] Q)
    {
        int N = S.Length;
        int M = P.Length;
        int[,] prefix = new int[4, N + 1];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < 4; j++)
                prefix[j, i + 1] = prefix[j, i];
            switch (S[i])
            {
                case 'A': prefix[0, i + 1]++; break;
                case 'C': prefix[1, i + 1]++; break;
                case 'G': prefix[2, i + 1]++; break;
                case 'T': prefix[3, i + 1]++; break;
            }
        }
        int[] result = new int[M];
        for (int k = 0; k < M; k++)
        {
            int from = P[k];
            int to = Q[k] + 1;
            for (int j = 0; j < 4; j++)
            {
                if (prefix[j, to] - prefix[j, from] > 0)
                {
                    result[k] = j + 1;
                    break;
                }
            }
        }
        return result;
    }

    // Test for GenomicRangeQuery
    public static void GenomicRangeQuery_Test()
    {
        string S = "CAGCCTA";
        int[] P = { 2, 5, 0 };
        int[] Q = { 4, 5, 6 };
        int[] result = GenomicRangeQuery(S, P, Q);
        Console.WriteLine($"GenomicRangeQuery('CAGCCTA', [2,5,0], [4,5,6]) = [{string.Join(", ", result)}] (expected [2, 4, 1])");
    }

    // MinAvgTwoSlice: Returns the starting position of the slice with the minimal average
    // Only slices of length 2 or 3 need to be checked for the minimum average
    public static int MinAvgTwoSlice(int[] A)
    {
        int N = A.Length;
        double minAvg = double.MaxValue;
        int minPos = 0;
        for (int i = 0; i < N - 1; i++)
        {
            double avg2 = (A[i] + A[i + 1]) / 2.0;
            if (avg2 < minAvg)
            {
                minAvg = avg2;
                minPos = i;
            }
            if (i < N - 2)
            {
                double avg3 = (A[i] + A[i + 1] + A[i + 2]) / 3.0;
                if (avg3 < minAvg)
                {
                    minAvg = avg3;
                    minPos = i;
                }
            }
        }
        return minPos;
    }

    // Test for MinAvgTwoSlice
    public static void MinAvgTwoSlice_Test()
    {
        int[] A = { 4, 2, 2, 5, 1, 5, 8 };
        int result = MinAvgTwoSlice(A);
        Console.WriteLine($"MinAvgTwoSlice([4,2,2,5,1,5,8]) = {result} (expected 1)");
    }
}
