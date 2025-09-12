using System;
using System.Collections.Generic;

public static class Lesson7
{
    // Brackets: Returns 1 if S is properly nested, 0 otherwise.
    // Uses a stack to check for matching opening and closing brackets.
    public static int Brackets(string S)
    {
        var stack = new Stack<char>();
        foreach (char c in S)
        {
            if (c == '(' || c == '[' || c == '{')
                stack.Push(c);
            else
            {
                if (stack.Count == 0)
                    return 0;
                char open = stack.Pop();
                if ((c == ')' && open != '(') ||
                    (c == ']' && open != '[') ||
                    (c == '}' && open != '{'))
                    return 0;
            }
        }
        return stack.Count == 0 ? 1 : 0;
    }

    // Test for Brackets
    public static void Brackets_Test()
    {
        string s1 = "{[()()]}";
        string s2 = "([)()]";
        int result1 = Brackets(s1);
        int result2 = Brackets(s2);
        Console.WriteLine($"Brackets('{{[()()]}}') = {result1} (expected 1)");
        Console.WriteLine($"Brackets('([)()]') = {result2} (expected 0)");
    }

    // Fish: Returns the number of fish that will stay alive.
    // Uses a stack to simulate downstream fish and resolves encounters with upstream fish.
    public static int Fish(int[] A, int[] B)
    {
        int alive = 0;
        var stack = new Stack<int>();
        for (int i = 0; i < A.Length; i++)
        {
            if (B[i] == 1)
            {
                stack.Push(A[i]);
            }
            else
            {
                while (stack.Count > 0)
                {
                    if (stack.Peek() > A[i])
                    {
                        goto NextFish;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                alive++;
            NextFish:;
            }
        }
        return alive + stack.Count;
    }

    // Test for Fish
    public static void Fish_Test()
    {
        int[] A = { 4, 3, 2, 1, 5 };
        int[] B = { 0, 1, 0, 0, 0 };
        int result = Fish(A, B);
        Console.WriteLine($"Fish([4,3,2,1,5], [0,1,0,0,0]) = {result} (expected 2)");
    }

    // Nesting: Returns 1 if S is properly nested with only '(', ')', 0 otherwise.
    public static int Nesting(string S)
    {
        int open = 0;
        foreach (char c in S)
        {
            if (c == '(') open++;
            else if (c == ')')
            {
                open--;
                if (open < 0) return 0;
            }
        }
        return open == 0 ? 1 : 0;
    }

    // Test for Nesting
    public static void Nesting_Test()
    {
        string s1 = "(()(())())";
        string s2 = "())";
        int result1 = Nesting(s1);
        int result2 = Nesting(s2);
        Console.WriteLine($"Nesting('(()(())())') = {result1} (expected 1)");
        Console.WriteLine($"Nesting('())') = {result2} (expected 0)");
    }

    // StoneWall: Returns the minimum number of blocks needed to build the wall.
    // Uses a stack to track the heights of the wall.
    public static int StoneWall(int[] H)
    {
        int blocks = 0;
        var stack = new Stack<int>();
        foreach (int height in H)
        {
            while (stack.Count > 0 && stack.Peek() > height)
                stack.Pop();
            if (stack.Count == 0 || stack.Peek() < height)
            {
                stack.Push(height);
                blocks++;
            }
        }
        return blocks;
    }

    // Test for StoneWall
    public static void StoneWall_Test()
    {
        int[] H = { 8, 8, 5, 7, 9, 8, 7, 4, 8 };
        int result = StoneWall(H);
        Console.WriteLine($"StoneWall([8,8,5,7,9,8,7,4,8]) = {result} (expected 7)");
    }
}
