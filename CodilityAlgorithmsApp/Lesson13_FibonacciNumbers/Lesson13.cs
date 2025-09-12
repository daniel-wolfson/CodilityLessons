using System;
using System.Collections.Generic;

public static class Lesson13
{
    // FibFrog: Returns the minimum number of jumps for the frog to cross the river using Fibonacci jumps.
    // Uses BFS and precomputes Fibonacci numbers up to N+1.
    public static int FibFrog(int[] A)
    {
        int N = A.Length;
        var fibs = new List<int> { 1, 2 };
        while (fibs[fibs.Count - 1] <= N + 1)
            fibs.Add(fibs[^1] + fibs[^2]);
        var queue = new Queue<(int pos, int jumps)>();
        var visited = new bool[N + 2];
        queue.Enqueue((-1, 0));
        visited[0] = true;
        while (queue.Count > 0)
        {
            var (pos, jumps) = queue.Dequeue();
            foreach (var f in fibs)
            {
                int next = pos + f;
                if (next == N)
                    return jumps + 1;
                if (next > N || next < 0 || visited[next + 1])
                    continue;
                if (A[next] == 1)
                {
                    queue.Enqueue((next, jumps + 1));
                    visited[next + 1] = true;
                }
            }
        }
        return -1;
    }

    // Test for FibFrog
    public static void FibFrog_Test()
    {
        int[] A = { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 };
        int result = FibFrog(A);
        Console.WriteLine($"FibFrog([0,0,0,1,1,0,1,0,0,0,0]) = {result} (expected 3)");
    }

    // Ladder: Returns an array with the number of ways to climb each ladder modulo 2^B[i].
    // Uses precomputed Fibonacci numbers and modulo for each query.
    public static int[] Ladder(int[] A, int[] B)
    {
        int L = A.Length;
        int maxA = 0;
        foreach (var a in A) if (a > maxA) maxA = a;
        int[] fib = new int[maxA + 2];
        fib[0] = 1; fib[1] = 1;
        for (int i = 2; i <= maxA + 1; i++)
            fib[i] = (fib[i - 1] + fib[i - 2]) & 0x7FFFFFFF; // prevent overflow
        int[] result = new int[L];
        for (int i = 0; i < L; i++)
        {
            int mod = 1 << B[i];
            result[i] = fib[A[i]] % mod;
        }
        return result;
    }

    // Test for Ladder
    public static void Ladder_Test()
    {
        int[] A = { 4, 4, 5, 5, 1 };
        int[] B = { 3, 2, 4, 3, 1 };
        int[] result = Ladder(A, B);
        Console.WriteLine($"Ladder([4,4,5,5,1],[3,2,4,3,1]) = [{string.Join(", ", result)}] (expected [5,1,8,0,1])");
    }
}
