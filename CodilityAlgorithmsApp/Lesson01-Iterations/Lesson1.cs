public static class Lesson1
{
    public static int BinaryGap(int N)
    {
        string binary = Convert.ToString(N, 2);
        int maxGap = 0;
        int currentGap = 0;
        bool foundFirstOne = false;

        foreach (char bit in binary.ToCharArray())
        {
            if (bit == '1')
            {
                if (foundFirstOne)
                {
                    // We found the closing '1' of a potential gap
                    maxGap = Math.Max(maxGap, currentGap);
                }
                foundFirstOne = true;
                currentGap = 0;
            }
            else if (foundFirstOne)
            {
                // We're inside a potential gap (after finding the first '1')
                currentGap++;
            }
        }

        return maxGap;
    }

    public static int BinaryGap2(int N)
    {
        int value = 0;
        var results = new List<int>();
        var binary = Convert.ToString(N, 2);

        foreach (var c in binary)
        {
            if (c.Equals('0'))
            {
                value += 1;
            }
            else
            {
                results.Add(value);
                value = 0;
            }
        }

        return results.Max();
    }

    public static void BinaryGap_Test()
    {
        int result1 = BinaryGap(1041);
        Console.WriteLine($"BinaryGap(1041) = {result1} (expected 5)");
        int result2 = BinaryGap2(1041);
        Console.WriteLine($"BinaryGap(1041) = {result1} (expected 5)");
    }
}