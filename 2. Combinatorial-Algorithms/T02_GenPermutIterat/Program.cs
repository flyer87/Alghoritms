using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_GenPermutIterat
{
    class Program
    {
        static int n = 3;
        static int[] a = Enumerable.Range(1, n).ToArray();        
        static int[] p = Enumerable.Repeat(0, n).ToArray();    

        static void Main(string[] args)
        {
            int i = 1;
            PrintPermut();
            while (i < n)
            {
                if (p[i] < i)
                {
                    int j;
                    if (IsOdd(i)) { j = p[i]; } else { j = 0; }
                    Swap(ref a[j],ref a[i]);
                    p[i]++;
                    i = 1;

                    PrintPermut();                    
                }
                else
                {
                    p[i] = 0;
                    i++;                    
                }                
            }            
        }

        private static void PrintPermut()
        {
            Console.WriteLine("{0} ", String.Join(", ", a));
            
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
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
