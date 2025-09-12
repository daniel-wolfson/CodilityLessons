using System;
using System.Collections.Generic;

public static class Lesson14
{
    // MinMaxDivision: Returns the minimal large sum after dividing array A into K blocks.
    // Uses binary search to find the minimal possible maximal block sum.
    public static int MinMaxDivision(int K, int M, int[] A)
    {
        int lower = 0, upper = 0;
        foreach (var a in A)
        {
            if (a > lower) lower = a;
            upper += a;
        }
        int result = upper;
        while (lower <= upper)
        {
            int mid = (lower + upper) / 2;
            if (CanDivide(A, K, mid))
            {
                result = mid;
                upper = mid - 1;
            }
            else
            {
                lower = mid + 1;
            }
        }
        return result;
    }

    // Helper for MinMaxDivision: checks if A can be divided into K blocks with max sum <= maxBlockSum
    private static bool CanDivide(int[] A, int K, int maxBlockSum)
    {
        int blocks = 1, currentSum = 0;
        foreach (var a in A)
        {
            if (currentSum + a > maxBlockSum)
            {
                blocks++;
                currentSum = a;
                if (blocks > K) return false;
            }
            else
            {
                currentSum += a;
            }
        }
        return true;
    }

    // Test for MinMaxDivision
    public static void MinMaxDivision_Test()
    {
        int K = 3, M = 5;
        int[] A = { 2, 1, 5, 1, 2, 2, 2 };
        int result = MinMaxDivision(K, M, A);
        Console.WriteLine($"MinMaxDivision(3, 5, [2,1,5,1,2,2,2]) = {result} (expected 6)");
    }

    // NailingPlanks: Returns the minimum number of nails needed to nail all planks.
    // Uses binary search and prefix sums for efficient checking.
    public static int NailingPlanks(int[] A, int[] B, int[] C)
    {
        int N = A.Length, M = C.Length;
        int result = -1, left = 1, right = M;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (AllPlanksNailed(A, B, C, mid))
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return result;
    }

    // Helper for NailingPlanks: checks if all planks are nailed with first nailsCount nails
    private static bool AllPlanksNailed(int[] A, int[] B, int[] C, int nailsCount)
    {
        int M = C.Length;
        int maxPos = 2 * M + 2;
        int[] prefix = new int[maxPos + 1];
        for (int i = 0; i < nailsCount; i++)
            prefix[C[i]] = 1;
        for (int i = 1; i <= maxPos; i++)
            prefix[i] += prefix[i - 1];
        for (int i = 0; i < A.Length; i++)
        {
            if (prefix[B[i]] - prefix[A[i] - 1] == 0)
                return false;
        }
        return true;
    }

    // Test for NailingPlanks
    public static void NailingPlanks_Test()
    {
        int[] A = { 1, 4, 5, 8 };
        int[] B = { 4, 5, 9, 10 };
        int[] C = { 4, 6, 7, 10, 2 };
        int result = NailingPlanks(A, B, C);
        Console.WriteLine($"NailingPlanks([1,4,5,8],[4,5,9,10],[4,6,7,10,2]) = {result} (expected 4)");
    }
}
