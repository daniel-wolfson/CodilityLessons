public static class Lesson8
{
    // Dominator: Returns the index of any element of array A in which the dominator occurs.
    // The dominator is the value that occurs in more than half of the elements of A.
    // Returns -1 if there is no dominator.
    public static int Dominator(int[] A)
    {
        int size = 0, value = 0;
        // Find a candidate for dominator using the stack method
        foreach (var num in A)
        {
            if (size == 0)
            {
                size++;
                value = num;
            }
            else
            {
                if (num == value)
                    size++;
                else
                    size--;
            }
        }
        if (size == 0)
            return -1;
        int count = 0, index = -1;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == value)
            {
                count++;
                index = i;
            }
        }
        return count > A.Length / 2 ? index : -1;
    }

    // Test for Dominator
    public static void Dominator_Test()
    {
        int[] A = { 3, 4, 3, 2, 3, -1, 3, 3 };
        int result = Dominator(A);
        Console.WriteLine($"Dominator([3,4,3,2,3,-1,3,3]) = {result} (expected any of 0,2,4,6,7)");
    }

    // EquiLeader: Returns the number of equi leaders in array A.
    // An equi leader is an index S such that both sequences A[0..S] and A[S+1..N-1] have the same leader.
    public static int EquiLeader(int[] A)
    {
        // Find the leader using the same method as Dominator
        int size = 0, value = 0;
        foreach (var num in A)
        {
            if (size == 0)
            {
                size++;
                value = num;
            }
            else
            {
                if (num == value)
                    size++;
                else
                    size--;
            }
        }
        int leader = -1, count = 0;
        foreach (var num in A)
            if (num == value) count++;
        if (count > A.Length / 2)
            leader = value;
        else
            return 0;
        int equiLeaders = 0, leftCount = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == leader)
                leftCount++;
            if (leftCount > (i + 1) / 2 && (count - leftCount) > (A.Length - i - 1) / 2)
                equiLeaders++;
        }
        return equiLeaders;
    }

    // Test for EquiLeader
    public static void EquiLeader_Test()
    {
        int[] A = { 4, 3, 4, 4, 4, 2 };
        int result = EquiLeader(A);
        Console.WriteLine($"EquiLeader([4,3,4,4,4,2]) = {result} (expected 2)");
    }
}
