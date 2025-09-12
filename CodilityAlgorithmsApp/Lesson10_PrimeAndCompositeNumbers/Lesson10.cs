using System;

public static class Lesson10
{
    // CountFactors: Returns the number of factors of N.
    // For each i from 1 to sqrt(N), if N % i == 0, count both i and N/i.
    public static int CountFactors(int N)
    {
        int count = 0;
        int i = 1;
        while (i * i < N)
        {
            if (N % i == 0)
                count += 2;
            i++;
        }
        if (i * i == N)
            count++;
        return count;
    }

    // Test for CountFactors
    public static void CountFactors_Test()
    {
        int N = 24;
        int result = CountFactors(N);
        Console.WriteLine($"CountFactors(24) = {result} (expected 8)");
    }

    // MinPerimeterRectangle: Returns the minimal perimeter of any rectangle with area N.
    // For each i from 1 to sqrt(N), if N % i == 0, perimeter is 2 * (i + N/i).
    public static int MinPerimeterRectangle(int N)
    {
        int minPerimeter = int.MaxValue;
        for (int i = 1; i * i <= N; i++)
        {
            if (N % i == 0)
            {
                int perimeter = 2 * (i + N / i);
                if (perimeter < minPerimeter)
                    minPerimeter = perimeter;
            }
        }
        return minPerimeter;
    }

    // Test for MinPerimeterRectangle
    public static void MinPerimeterRectangle_Test()
    {
        int N = 30;
        int result = MinPerimeterRectangle(N);
        Console.WriteLine($"MinPerimeterRectangle(30) = {result} (expected 22)");
    }

    // Flags: Returns the maximum number of flags that can be set on the peaks.
    // A peak is an element that is larger than its neighbors.
    public static int Flags(int[] A)
    {
        int N = A.Length;
        var peaks = new System.Collections.Generic.List<int>();
        for (int i = 1; i < N - 1; i++)
            if (A[i] > A[i - 1] && A[i] > A[i + 1])
                peaks.Add(i);
        if (peaks.Count == 0)
            return 0;
        int maxFlags = 1;
        int left = 1, right = peaks.Count;
        while (left <= right)
        {
            int flags = (left + right) / 2;
            int used = 1, last = peaks[0];
            for (int i = 1; i < peaks.Count; i++)
            {
                if (peaks[i] - last >= flags)
                {
                    used++;
                    last = peaks[i];
                    if (used == flags) break;
                }
            }
            if (used == flags)
            {
                maxFlags = flags;
                left = flags + 1;
            }
            else
            {
                right = flags - 1;
            }
        }
        return maxFlags;
    }

    // Test for Flags
    public static void Flags_Test()
    {
        int[] A = { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
        int result = Flags(A);
        Console.WriteLine($"Flags([1,5,3,4,3,4,1,2,3,4,6,2]) = {result} (expected 3)");
    }

    // Peaks: Returns the maximum number of blocks into which the array can be divided so that each block contains at least one peak.
    public static int Peaks(int[] A)
    {
        int N = A.Length;
        var peaks = new bool[N];
        int totalPeaks = 0;
        for (int i = 1; i < N - 1; i++)
        {
            if (A[i] > A[i - 1] && A[i] > A[i + 1])
            {
                peaks[i] = true;
                totalPeaks++;
            }
        }
        for (int size = 1; size <= N; size++)
        {
            if (N % size != 0) continue;
            int blockSize = N / size;
            int found = 0;
            for (int i = 0; i < N; i += blockSize)
            {
                bool hasPeak = false;
                for (int j = i; j < i + blockSize; j++)
                {
                    if (peaks[j])
                    {
                        hasPeak = true;
                        break;
                    }
                }
                if (hasPeak) found++;
                else break;
            }
            if (found == size) return size;
        }
        return 0;
    }

    // Test for Peaks
    public static void Peaks_Test()
    {
        int[] A = { 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
        int result = Peaks(A);
        Console.WriteLine($"Peaks([1,2,3,4,3,4,1,2,3,4,6,2]) = {result} (expected 3)");
    }
}
