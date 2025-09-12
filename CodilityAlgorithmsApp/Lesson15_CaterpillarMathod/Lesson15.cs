using System;
using System.Collections.Generic;

public static class Lesson15
{
    // AbsoluteDistinct: Returns the number of distinct absolute values in a sorted array A.
    // Uses two pointers to efficiently count unique absolute values.
    public static int AbsoluteDistinct(int[] A)
    {
        int N = A.Length;
        int left = 0, right = N - 1, count = 0;
        int lastAbs = int.MinValue;
        while (left <= right)
        {
            int leftAbs = Math.Abs(A[left]);
            int rightAbs = Math.Abs(A[right]);
            int currentAbs;
            if (leftAbs > rightAbs)
            {
                currentAbs = leftAbs;
                left++;
            }
            else if (leftAbs < rightAbs)
            {
                currentAbs = rightAbs;
                right--;
            }
            else
            {
                currentAbs = leftAbs;
                left++;
                right--;
            }
            if (currentAbs != lastAbs)
            {
                count++;
                lastAbs = currentAbs;
            }
        }
        return count;
    }

    // Test for AbsoluteDistinct
    public static void AbsoluteDistinct_Test()
    {
        int[] A = { -5, -3, -1, 0, 3, 6 };
        int result = AbsoluteDistinct(A);
        Console.WriteLine($"AbsoluteDistinct([-5,-3,-1,0,3,6]) = {result} (expected 5)");
    }

    // CountDistinctSlices: Returns the number of distinct slices in array A (all unique subarrays).
    // Uses a sliding window and a boolean array to track seen values.
    public static int CountDistinctSlices(int M, int[] A)
    {
        int N = A.Length;
        var seen = new bool[M + 1];
        int left = 0, right = 0, count = 0;
        while (left < N && right < N)
        {
            if (!seen[A[right]])
            {
                seen[A[right]] = true;
                count += right - left + 1;
                if (count > 1000000000) return 1000000000;
                right++;
            }
            else
            {
                seen[A[left]] = false;
                left++;
            }
        }
        return count;
    }

    // Test for CountDistinctSlices
    public static void CountDistinctSlices_Test()
    {
        int M = 6;
        int[] A = { 3, 4, 5, 5, 2 };
        int result = CountDistinctSlices(M, A);
        Console.WriteLine($"CountDistinctSlices(6, [3,4,5,5,2]) = {result} (expected 9)");
    }

    // CountTriangles: Returns the number of triplets that can form a triangle.
    // Sorts the array and uses a triple nested loop to count valid triangles.
    public static int CountTriangles(int[] A)
    {
        Array.Sort(A);
        int N = A.Length, count = 0;
        for (int i = 0; i < N - 2; i++)
        {
            int k = i + 2;
            for (int j = i + 1; j < N - 1; j++)
            {
                while (k < N && (long)A[i] + A[j] > A[k])
                    k++;
                count += k - j - 1;
            }
        }
        return count;
    }

    // Test for CountTriangles
    public static void CountTriangles_Test()
    {
        int[] A = { 10, 2, 5, 1, 8, 12 };
        int result = CountTriangles(A);
        Console.WriteLine($"CountTriangles([10,2,5,1,8,12]) = {result} (expected 4)");
    }

    // MinAbsSumOfTwo: Returns the minimal absolute sum of any pair in array A.
    // Uses two pointers after sorting the array.
    public static int MinAbsSumOfTwo(int[] A)
    {
        Array.Sort(A);
        int left = 0, right = A.Length - 1;
        int minAbs = int.MaxValue;
        while (left <= right)
        {
            int sum = A[left] + A[right];
            minAbs = Math.Min(minAbs, Math.Abs(sum));
            if (Math.Abs(A[left]) > Math.Abs(A[right]))
                left++;
            else
                right--;
        }
        return minAbs;
    }

    // Test for MinAbsSumOfTwo
    public static void MinAbsSumOfTwo_Test()
    {
        int[] A1 = { 1, 4, -3 };
        int[] A2 = { -8, 4, 5, -10, 3 };
        int result1 = MinAbsSumOfTwo(A1);
        int result2 = MinAbsSumOfTwo(A2);
        Console.WriteLine($"MinAbsSumOfTwo([1,4,-3]) = {result1} (expected 1)");
        Console.WriteLine($"MinAbsSumOfTwo([-8,4,5,-10,3]) = {result2} (expected 3)");
    }
}
