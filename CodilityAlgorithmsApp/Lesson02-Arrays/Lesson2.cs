public static class Lesson2
{
    // CyclicRotation: Rotates array A K times to the right.
    // Each element is shifted right by one index, and the last element moves to the first place.
    // Example: A = [3, 8, 9, 7, 6], K = 3 => [9, 7, 6, 3, 8]
    // If K > N, only K % N rotations are needed.
    public static int[] Rotaition(int[] A, int K)
    {
        // Handle edge cases
        if (A.Length == 0 || K == 0)
        {
            return A;
        }

        int N = A.Length;
        // Optimize K: if K > N, we only need K % N rotations
        K = K % N;

        // If K is 0 after modulo, no rotation needed
        if (K == 0)
        {
            return A;
        }

        // Create result array
        int[] result = new int[N];

        // Copy elements to their new positions
        for (int i = 0; i < N; i++)
        {
            // Element at position i goes to position (i + K) % N
            result[(i + K) % N] = A[i];
        }

        return result;
    }

    // Test method for CyclicRotation
    public static void Rotaition_Test()
    {
        int[] A = { 3, 8, 9, 7, 6 };
        int K = 3;
        int[] result = Rotaition(A, K);
        Console.WriteLine($"Rotaition([3,8,9,7,6], 3) = [{string.Join(", ", result)}] (expected [9, 7, 6, 3, 8])");
    }

    // OddOccurrencesInArray: Finds the value of the unpaired element in array A.
    // The array contains an odd number of elements, and all but one value occur an even number of times.
    // Example: A = [9, 3, 9, 3, 9, 7, 9] => returns 7 (7 is unpaired)
    public static int OddOccurrencesInArray(int[] A)
    {
        int result = 0;
        foreach (var number in A)
        {
            // XOR-ing all numbers leaves only the unpaired one
            result ^= number;
        }
        return result;
    }

    public static int OddOccurrencesInArray2(int[] A)
    {
        return A.Aggregate((x, y) => x ^ y);
    }

    // Test method for OddOccurrencesInArray
    public static void OddOccurrencesInArray_Test()
    {
        int[] A = { 9, 3, 9, 3, 9, 7, 9 };
        int result = OddOccurrencesInArray(A);
        Console.WriteLine($"OddOccurrencesInArray([9,3,9,3,9,7,9]) = {result} (expected 7)");
        int result2 = OddOccurrencesInArray2(A);
    }

    // CyclicRotation: Rotates array A K times to the right.
    // Each element is shifted right by one index, and the last element moves to the first place.
    // Example: A = [3, 8, 9, 7, 6], K = 3 => [9, 7, 6, 3, 8]
    // If K > N, only K % N rotations are needed.
    public static int[] Rotaition2(int[] A, int K)
    {
        int[] values = A;

        for (int i = 0; i < K; i++)
        {
            values = Swap(values);
        }

        return values;
    }

    private static int[] Swap(int[] intArray)
    {
        int[] newArray = new int[intArray.Length];

        if (newArray.Length == 0)
        {
            return newArray;
        }
        else
        {
            newArray[0] = intArray[intArray.Length - 1];

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                newArray[i + 1] = intArray[i];
            }
        }

        return newArray;
    }
}