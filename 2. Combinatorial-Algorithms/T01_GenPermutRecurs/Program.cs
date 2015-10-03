using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_GenPermutRecurs
{
    class Program
    {
        static private int cntOfPermut = 0;
        static int n = 3;
        static int[] arr = Enumerable.Range(1, n).ToArray();

        static void Main(string[] args)
        {
            // Genereate Perm.
            Permute(arr);
            Console.WriteLine("Total permuataions: {0}", cntOfPermut);
        }

        private static void Permute(int[] arr, int startIndex = 0)
        {
            if (startIndex >= arr.Length)
            {
                cntOfPermut++;
                PrintPermut();
            }

            for (int i = startIndex; i < arr.Length; i++)
            {
                Swap(ref arr[startIndex], ref arr[i]);
                Permute(arr, startIndex + 1);
                Swap(ref arr[i], ref arr[startIndex]);
            }
        }

        private static void PrintPermut()
        {
            Console.WriteLine("{0}", String.Join(", ", arr));
        }

        private static void Swap(ref int a, ref int b)
        {
            if (a == b)
            {
                return;
            }

            int temp = a;
            a = b;
            b = temp;
        }
    }
}
