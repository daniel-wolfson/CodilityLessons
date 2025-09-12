public static class Lesson12
{
    // ChocolatesByNumbers: Returns the number of chocolates eaten.
    // Uses the greatest common divisor (GCD) to determine the cycle length.
    public static int ChocolatesByNumbers(int N, int M)
    {
        return N / Gcd(N, M);
    }

    // Helper method to compute GCD using the Euclidean algorithm.
    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Test for ChocolatesByNumbers
    public static void ChocolatesByNumbers_Test()
    {
        int N = 10, M = 4;
        int result = ChocolatesByNumbers(N, M);
        Console.WriteLine($"ChocolatesByNumbers(10, 4) = {result} (expected 5)");
    }

    // CommonPrimeDivisors: Returns the number of positions where A[i] and B[i] have the same set of prime divisors.
    // Uses GCD and prime factorization logic.
    public static int CommonPrimeDivisors(int[] A, int[] B)
    {
        int count = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (HasSamePrimeDivisors(A[i], B[i]))
                count++;
        }
        return count;
    }

    // Helper to check if two numbers have the same set of prime divisors.
    private static bool HasSamePrimeDivisors(int a, int b)
    {
        int gcd = Gcd(a, b);
        return RemovePrimeDivisors(a, gcd) == 1 && RemovePrimeDivisors(b, gcd) == 1;
    }

    // Removes all prime divisors of x that are also in gcd.
    private static int RemovePrimeDivisors(int x, int gcd)
    {
        int tempGcd;
        while ((tempGcd = Gcd(x, gcd)) != 1)
        {
            x /= tempGcd;
        }
        return x;
    }

    // Test for CommonPrimeDivisors
    public static void CommonPrimeDivisors_Test()
    {
        int[] A = { 15, 10, 3 };
        int[] B = { 75, 30, 5 };
        int result = CommonPrimeDivisors(A, B);
        Console.WriteLine($"CommonPrimeDivisors([15,10,3], [75,30,5]) = {result} (expected 1)");
    }
}
