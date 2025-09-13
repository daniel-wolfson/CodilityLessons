public class Lesson3
{
    // FrogJmp: Returns the minimal number of jumps from position X to a position >= Y, with each jump of distance D.
    // The frog is currently at position X and wants to get to at least position Y.
    // Each jump moves the frog forward by D units.
    // The function returns the minimal number of jumps needed.
    // Example: X = 10, Y = 85, D = 30 => returns 3 (jumps to 40, 70, 100)
    public static int FrogJmp(int X, int Y, int D)
    {
        if (X >= Y) return 0;
        return (int)Math.Ceiling((double)(Y - X) / D);
    }

    // Test method for FrogJmp
    public static void FrogJmp_Test()
    {
        int X = 10, Y = 85, D = 30;
        int result = FrogJmp(X, Y, D);
        Console.WriteLine($"FrogJmp({X}, {Y}, {D}) = {result} (expected 3)");
    }

    // PermMissingElem: Returns the value of the missing element in the array A.
    // Array A contains N different integers in the range [1..N+1], exactly one element is missing.
    // The function returns the missing element.
    // Example: A = [2, 3, 1, 5] => returns 4
    public static int PermMissingElem(int[] A)
    {
        int n = A.Length + 1;
        long expectedSum = (long)n * (n + 1) / 2;
        long actualSum = 0;
        foreach (var num in A)
        {
            actualSum += num;
        }
        return (int)(expectedSum - actualSum);
    }

    public static int PermMissingElem2(int[] A)
    {
        var values = A.OrderBy(x => x).ToList();
        var result = 0;

        // Optimized missing element detection for edge cases
        if (values.Count == 0)
            result = 1;
        else if (values.Count == 1)
            result = values[0] == 1 ? 2 : 1;
        else if (values[0] == 2)
            result = 1;
        else
            result = 0;

        if (result == 0)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                if (values[i + 1] != values[i] + 1)
                {
                    result = values[i] + 1;
                    break;
                }
                else if (values[i + 1] == values[values.Count - 1])
                {
                    result = values[i + 1] + 1;
                    break;
                }
            }
        }

        return result;

    }

    // Test method for PermMissingElem
    public static void PermMissingElem_Test()
    {
        int[] A = { 2, 3, 1, 5 };
        int result = PermMissingElem(A);
        int result2 = PermMissingElem2(A);
        Console.WriteLine($"PermMissingElem([2,3,1,5]) = {result} (expected 4)");
        Console.WriteLine($"PermMissingElem([2,3,1,5]) = {result2} (expected 4)");
    }

    // TapeEquilibrium: Returns the minimal difference that can be achieved by splitting the array A.
    // Array A represents numbers on a tape. Any integer P (0 < P < N) splits the tape into two parts.
    // The function returns the minimal absolute difference between the sum of the first part and the sum of the second part.
    // Example: A = [3, 1, 2, 4, 3] => returns 1 (split at P=3: |6-7|=1)
    public static int TapeEquilibrium(int[] A)
    {
        int totalSum = 0;
        foreach (var num in A)
            totalSum += num;

        int minDiff = int.MaxValue;
        int leftSum = 0;

        // Split at every position P where 1 <= P < A.Length
        for (int P = 1; P < A.Length; P++)
        {
            leftSum += A[P - 1];
            int rightSum = totalSum - leftSum;
            int diff = Math.Abs(leftSum - rightSum);
            if (diff < minDiff)
                minDiff = diff;
        }
        return minDiff;
    }

    // Test method for TapeEquilibrium
    public static void TapeEquilibrium_Test()
    {
        int[] A = { 3, 1, 2, 4, 3 };
        int result = TapeEquilibrium(A);
        Console.WriteLine($"TapeEquilibrium([3,1,2,4,3]) = {result} (expected 1)");
    }
}