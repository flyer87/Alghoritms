using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T04_SubsetsOfStringArray
{
    class Program
    {
        static int k = 2;
        static int[] arr = new int[k];
        static string[] set = new[] { "test", "rock", "fun" };
        static int n = set.Length;

        static void Main(string[] args)
        {
            GenCombinations(arr, 0);
        }

        private static void GenCombinations(int[] arr, int index, int startDigit = 0)
        {
            if (index >= arr.Length)
            {
                PrintComb();
                return;
            }
            else
            {
                for (int i = startDigit; i < n; i++)
                {
                    arr[index] = i;
                    GenCombinations(arr, index + 1, i + 1);
                }
            }
        }

        private static void PrintComb()
        {
            Console.WriteLine("({0})", String.Join(" ", arr.Select(i => set[i])));
        }
    }
}
