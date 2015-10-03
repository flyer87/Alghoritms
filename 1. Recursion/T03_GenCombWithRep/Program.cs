using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_GenCombWithRep
{
    class Program
    {
        static int n = 3;
        static int k = 2;
        static int[] arr = new int[k];

        static void Main(string[] args)
        {
            GenenerateCombWithRep(arr, 0);
        }

        private static void GenenerateCombWithRep(int[] arr, int index, int startDig = 1)
        {
            if (index >= arr.Length)
            {
                PrintComb();
            }
            else
            {
                for (int i = startDig; i <= n; i++)
                {
                    arr[index] = i;
                    GenenerateCombWithRep(arr, index + 1, i);
                }
            }
        }

        private static void PrintComb()
        {
            Console.WriteLine("{0}", String.Join(" ", arr));
        }
    }
}