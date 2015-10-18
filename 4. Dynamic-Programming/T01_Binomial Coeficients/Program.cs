using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binomial_Coeficients
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int k = 2;
            int coef = GetBinomialCoefiecient(n, k);
            Console.WriteLine("By n={0}, k={1}, coeficient={2}", n, k, coef);

        }

        private static int GetBinomialCoefiecient(int n, int k)
        {
            int[] lastCoeficients = new int[n + 1];
            int[] currentCoeficients = new int[n + 1];

            lastCoeficients[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                currentCoeficients[0] = 1;
                for (int j = 1; j <= (n - 1); j++)
                {
                    currentCoeficients[j] = lastCoeficients[j] + lastCoeficients[j - 1];
                }

                currentCoeficients[i] = 1;
                Array.Copy(currentCoeficients, lastCoeficients , currentCoeficients.Length);
            }

            Console.WriteLine("[{0}]", String.Join(", ", currentCoeficients));

            return currentCoeficients[k];
        }
    }
}
