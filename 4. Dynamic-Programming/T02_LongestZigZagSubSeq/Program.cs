using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_LongestZigZagSubSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seq = {1, 1, 1,  17,  5,  10,  13,  15,  10,  5,  16,  8 }; // { 24, 5, 31, 3, 3, 342, 51, 114, 52, 55, 56, 58 }; //{ 1, 2, 3 }; //{ 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 };   
            int[] result = GetLongestZigZagSubSequence(seq);

            Console.WriteLine(string.Join(", ", result));
        }

        private static int[] GetLongestZigZagSubSequence(int[] seq)
        {
            int[,] matrix = new int[seq.Length, 2];
            int[] prev = new int[seq.Length];

            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            int bestLength = 1;
            int lastIndex = 0;

            for (int i = 1; i < seq.Length; i++)
            {
                matrix[i, 0] = 1;
                matrix[i, 1] = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if ((seq[i] - seq[j]) > 0)
                    {
                        matrix[i, 0] = Math.Max(matrix[j, 1] + 1, matrix[i, 0]);
                    }
                    else if ((seq[i] - seq[j]) < 0)
                    {
                        matrix[i, 1] = Math.Max(matrix[j, 0] + 1, matrix[i, 1]);
                    }
                }

                if (Math.Max(matrix[i, 0], matrix[i, 1]) > bestLength)
                {
                    bestLength = Math.Max(bestLength, Math.Max(matrix[i, 0], matrix[i, 1]));
                    lastIndex = i;
                }
            }

            // get result
            //int startIndex = lastIndex;
            //int[] result = new int[best];
            //int arrayIndex = 0;

            //int currentLength = best;
            //int cell = (matrix[lastIndex, 0] == best) ? 0 : 1;
            //bool boolCell = (cell == 1) ? true : false;

            //while (startIndex >= 0)
            //{
            //    if ((matrix[startIndex, cell] == currentLength) && (result[arrayIndex] != matrix[startIndex, cell]))
            //    {
            //        boolCell = !boolCell;
            //        cell = (boolCell == true) ? 1 : 0;
            //        result[arrayIndex] = seq[startIndex];
            //        arrayIndex++;
            //        currentLength--;
            //    }              
            //    startIndex--;                
            //}


            // get result
            int[] result = new int[bestLength];
            result[0] = seq[0];
            int arrayIndex = 1;

            int startIndex = 1;          
            while (Math.Max(matrix[startIndex, 0], matrix[startIndex, 1]) != 2)
            {
                startIndex++;
            }

            int currentLength = 2;
            int cell = (matrix[startIndex, 0] == currentLength) ? 0 : 1;
            bool boolCell = (cell == 1) ? true : false;
            
            while (currentLength <= bestLength)
            {
                if ((matrix[startIndex, cell] == currentLength) && (result[arrayIndex - 1] != seq[startIndex]))
                {
                    boolCell = !boolCell;
                    cell = (boolCell == true) ? 1 : 0;
                    result[arrayIndex] = seq[startIndex];
                    arrayIndex++;
                    currentLength++;
                }

                startIndex++;
            }

            return result;
        }
    }
}
