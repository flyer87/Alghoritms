using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T02_NestedLoopsRecursion
{
    class Program
    {
        static int numNestedLoops = 3;
        static int[] arrNumbers = new int[numNestedLoops];

        static void Main(string[] args)
        {
            NestedLoopToRecusrion(arrNumbers, 0);
        }

        static void NestedLoopToRecusrion(int[] arr, int index)
        {
            if (index >= arr.GetLength(0))
            {
                PrintArr();
                return;
            }
            else
            {
                for (int i = 1; i <= numNestedLoops; i++)
                {
                    arr[index] = i;
                    NestedLoopToRecusrion(arr, index + 1);
                }
            }
        }

        static void PrintArr()
        {
            for (int i = 0; i < arrNumbers.Length; i++)
            {
                Console.Write(arrNumbers[i] + " ");                
            }
            Console.WriteLine();
        }
    }
}
