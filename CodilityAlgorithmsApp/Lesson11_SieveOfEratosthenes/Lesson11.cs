using System;
using System.Collections.Generic;

public static class Lesson11
{
    // CountNonDivisible: For each element in A, returns the number of elements not divisible by it.
    // Uses a sieve and frequency dictionary for efficient counting.
    public static int[] CountNonDivisible(int[] A)
    {
        int N = A.Length;
        int max = 0;
        foreach (var num in A)
            if (num > max) max = num;
        var count = new int[max + 1];
        foreach (var num in A)
            count[num]++;
        var divisors = new int[max + 1];
        for (int i = 1; i <= max; i++)
        {
            for (int j = i; j <= max; j += i)
                divisors[j] += count[i];
        }
        var result = new int[N];
        for (int i = 0; i < N; i++)
            result[i] = N - divisors[A[i]];
        return result;
    }

    // Test for CountNonDivisible
    public static void CountNonDivisible_Test()
    {
        int[] A = { 3, 1, 2, 3, 6 };
        int[] result = CountNonDivisible(A);
        Console.WriteLine($"CountNonDivisible([3,1,2,3,6]) = [{string.Join(", ", result)}] (expected [2,4,3,2,0])");
    }

    // CountSemiprimes: Returns an array with the number of semiprimes within each range [P[K], Q[K]].
    // Uses a sieve to find primes and prefix sums for fast queries.
    public static int[] CountSemiprimes(int N, int[] P, int[] Q)
    {
        var isPrime = new bool[N + 1];
        for (int i = 2; i <= N; i++) isPrime[i] = true;
        for (int i = 2; i * i <= N; i++)
            if (isPrime[i])
                for (int k = i * i; k <= N; k += i)
                    isPrime[k] = false;
        var isSemi = new bool[N + 1];
        for (int i = 2; i <= N; i++)
            if (isPrime[i])
                for (int j = i; i * j <= N; j++)
                    if (isPrime[j])
                        isSemi[i * j] = true;
        var prefix = new int[N + 1];
        for (int i = 1; i <= N; i++)
            prefix[i] = prefix[i - 1] + (isSemi[i] ? 1 : 0);
        int M = P.Length;
        var result = new int[M];
        for (int i = 0; i < M; i++)
            result[i] = prefix[Q[i]] - prefix[P[i] - 1];
        return result;
    }

    // Test for CountSemiprimes
    public static void CountSemiprimes_Test()
    {
        int N = 26;
        int[] P = { 1, 4, 16 };
        int[] Q = { 26, 10, 20 };
        int[] result = CountSemiprimes(N, P, Q);
        Console.WriteLine($"CountSemiprimes(26, [1,4,16], [26,10,20]) = [{string.Join(", ", result)}] (expected [10,4,0])");
    }
}
