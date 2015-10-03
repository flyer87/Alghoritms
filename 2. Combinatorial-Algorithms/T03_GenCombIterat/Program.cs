using System;
using System.Collections.Generic;

public class Program
{
    public static IEnumerable<int[]> Combinations(int m, int n)
    {
        int[] result = new int[m];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);

        while (stack.Count > 0)
        {
            int index = stack.Count - 1;
            int value = stack.Pop();

            while (value < n)
            {
                result[index++] = value++;
                stack.Push(value);
                if (index == m)
                {
                    yield return result;
                    break;
                }
            }
        }
    }

    static void Main()
    {
        int cnt = 0;

        int n = Int32.Parse(Console.ReadLine());
        int k = Int32.Parse(Console.ReadLine());

        foreach (int[] c in Combinations(k, n))
        {
            for (int i = 0; i < c.Length; i++)
            {
                Console.Write(c[i] + 1 + " ");
            }
            Console.WriteLine();
            cnt++;
        }
        Console.WriteLine(cnt);
    }
}