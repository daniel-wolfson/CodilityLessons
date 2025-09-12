public static class Lesson4
{
    // FrogRiverOne: Find the earliest time when the frog can jump to the other side
    // X - the position to reach, A - array of falling leaves positions
    // The frog starts at position 0 and wants to reach position X+1.
    // Leaves fall at positions given by array A, where A[K] is the position at second K.
    // The frog can cross only when all positions from 1 to X are covered by leaves.
    // The function returns the earliest second when this is possible, or -1 if never possible.
    public static int FrogRiverOne(int X, int[] A)
    {
        // Use a HashSet to track unique positions where leaves have fallen
        var positions = new HashSet<int>();
        for (int i = 0; i < A.Length; i++)
        {
            // Only consider positions within the river (1 to X)
            if (A[i] <= X)
            {
                positions.Add(A[i]); // Add the position where a leaf has fallen
                                     // If all positions from 1 to X are covered, return the current time
                if (positions.Count == X)
                    return i;
            }
        }
        // If not all positions are covered, return -1
        return -1;
    }

    // Example method based on the paragraph "For example" from Readme4.1.md
    // Demonstrates the algorithm with X = 5 and a sample array A
    public static void FrogRiverOne_Test()
    {
        int X = 5;
        int[] A = { 1, 3, 1, 4, 2, 3, 5, 4 };
        // The earliest time when all positions from 1 to 5 are covered by leaves is 6
        int result = FrogRiverOne(X, A);
        Console.WriteLine($"Earliest time when the frog can jump: {result}");
        // Expected output: Earliest time when the frog can jump: 6
    }

    // PermCheck: Check if array A is a permutation of numbers from 1 to N
    // Returns 1 if A is a permutation, 0 otherwise
    // A permutation is a sequence containing each element from 1 to N once, and only once
    public static int PermCheck(int[] A)
    {
        int N = A.Length;
        var seen = new HashSet<int>();
        foreach (var num in A)
        {
            // If number is out of range or already seen, it's not a permutation
            if (num < 1 || num > N || !seen.Add(num))
                return 0;
        }
        // If all numbers from 1 to N are present exactly once, it's a permutation
        return seen.Count == N ? 1 : 0;
    }

    // Example method for PermCheck based on the paragraph "For example" from Readme4.2.md
    public static void PermCheck_Test()
    {
        int[] A1 = { 4, 1, 3, 2 };
        int[] A2 = { 4, 1, 3 };
        int result1 = PermCheck(A1);
        int result2 = PermCheck(A2);
        Console.WriteLine($"PermCheck([4,1,3,2]) = {result1} (expected 1)");
        Console.WriteLine($"PermCheck([4,1,3]) = {result2} (expected 0)");
    }

    // MaxCounters: Calculate the value of every counter after all operations
    // N - number of counters, A - array of operations
    // If A[K] = X (1 <= X <= N): increase(X)
    // If A[K] = N + 1: set all counters to the current maximum
    public static int[] MaxCounters(int N, int[] A)
    {
        int[] counters = new int[N];
        int max = 0; // The current maximum value of any counter
        int lastUpdate = 0; // The value to update all counters to after a max counter operation

        for (int i = 0; i < A.Length; i++)
        {
            int X = A[i];
            if (X >= 1 && X <= N)
            {
                // Lazy update: bring counter up to date if needed
                if (counters[X - 1] < lastUpdate)
                    counters[X - 1] = lastUpdate;
                counters[X - 1]++;
                if (counters[X - 1] > max)
                    max = counters[X - 1];
            }
            else if (X == N + 1)
            {
                // Record the max value for lazy update
                lastUpdate = max;
            }
        }

        // Final update for all counters that missed the last max counter operation
        for (int i = 0; i < N; i++)
        {
            if (counters[i] < lastUpdate)
                counters[i] = lastUpdate;
        }
        return counters;
    }

    // Example method for MaxCounters based on the paragraph "For example" from Readme4.3.md
    public static void MaxCounters_Test()
    {
        int N = 5;
        int[] A = [3, 4, 4, 6, 1, 4, 4];
        int[] result = MaxCounters(N, A);
        Console.WriteLine($"MaxCounters([3,4,4,6,1,4,4]) = [{string.Join(", ", result)}] (expected [3, 2, 2, 4, 2])");
    }
}
