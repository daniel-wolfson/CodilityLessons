public static class Lesson6
{
    // Distinct: Returns the number of distinct values in array A.
    // Uses a HashSet for O(N) time and space.
    public static int Distinct(int[] A)
    {
        var distinctValues = new HashSet<int>(A);
        return distinctValues.Count;
    }

    // Test for Distinct
    public static void Distinct_Test()
    {
        int[] A = { 2, 1, 1, 2, 3, 1 };
        int result = Distinct(A);
        Console.WriteLine($"Distinct([2,1,1,2,3,1]) = {result} (expected 3)");
    }

    // MaxProductOfThree: Returns the maximal product of any triplet in array A.
    // Sorts the array and checks the product of the three largest and two smallest with the largest.
    public static int MaxProductOfThree(int[] A)
    {
        Array.Sort(A);
        int n = A.Length;
        // The maximal product can be either:
        // - the product of the three largest numbers
        // - or the product of the two smallest (possibly negative) and the largest number
        int product1 = A[n - 1] * A[n - 2] * A[n - 3];
        int product2 = A[0] * A[1] * A[n - 1];
        return Math.Max(product1, product2);
    }

    // Test for MaxProductOfThree
    public static void MaxProductOfThree_Test()
    {
        int[] A = { -3, 1, 2, -2, 5, 6 };
        int result = MaxProductOfThree(A);
        Console.WriteLine($"MaxProductOfThree([-3,1,2,-2,5,6]) = {result} (expected 60)");
    }

    // Triangle: Returns 1 if there exists a triangular triplet, 0 otherwise.
    // Sorts the array and checks consecutive triplets for the triangle condition.
    public static int Triangle(int[] A)
    {
        if (A.Length < 3)
            return 0;
        Array.Sort(A);
        for (int i = 0; i < A.Length - 2; i++)
        {
            if ((long)A[i] + (long)A[i + 1] > (long)A[i + 2])
                return 1;
        }
        return 0;
    }

    // Test for Triangle
    public static void Triangle_Test()
    {
        int[] A1 = { 10, 2, 5, 1, 8, 20 };
        int[] A2 = { 10, 50, 5, 1 };
        int result1 = Triangle(A1);
        int result2 = Triangle(A2);
        Console.WriteLine($"Triangle([10,2,5,1,8,20]) = {result1} (expected 1)");
        Console.WriteLine($"Triangle([10,50,5,1]) = {result2} (expected 0)");
    }
}
