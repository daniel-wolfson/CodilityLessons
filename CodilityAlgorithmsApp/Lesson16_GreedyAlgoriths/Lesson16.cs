using System;

public static class Lesson16
{
    // MaxNonoverlappingSegments: Returns the size of a non-overlapping set containing a maximal number of segments.
    // Greedy approach: always pick the next segment that starts after the end of the last chosen segment.
    public static int MaxNonoverlappingSegments(int[] A, int[] B)
    {
        int N = A.Length;
        if (N == 0) return 0;
        int count = 1;
        int lastEnd = B[0];
        for (int i = 1; i < N; i++)
        {
            if (A[i] > lastEnd)
            {
                count++;
                lastEnd = B[i];
            }
        }
        return count;
    }

    // Test for MaxNonoverlappingSegments
    public static void MaxNonoverlappingSegments_Test()
    {
        int[] A = { 1, 3, 7, 9, 9 };
        int[] B = { 5, 6, 8, 9, 10 };
        int result = MaxNonoverlappingSegments(A, B);
        Console.WriteLine($"MaxNonoverlappingSegments([1,3,7,9,9],[5,6,8,9,10]) = {result} (expected 3)");
    }

    // TieRopes: Returns the maximum number of ropes of length >= K that can be created.
    // Greedy approach: tie ropes until the sum is >= K, then count and reset.
    public static int TieRopes(int K, int[] A)
    {
        int count = 0, length = 0;
        foreach (var rope in A)
        {
            length += rope;
            if (length >= K)
            {
                count++;
                length = 0;
            }
        }
        return count;
    }

    // Test for TieRopes
    public static void TieRopes_Test()
    {
        int K = 4;
        int[] A = { 1, 2, 3, 4, 1, 1, 3 };
        int result = TieRopes(K, A);
        Console.WriteLine($"TieRopes(4, [1,2,3,4,1,1,3]) = {result} (expected 3)");
    }
}
