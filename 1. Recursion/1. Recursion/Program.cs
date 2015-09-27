using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_01.Recursion
{
    class Program
    {
        private static int stepsTaken = 0;

        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        static void Main(string[] args)
        {
            int numberOfDiscs = 10;
            source = new Stack<int>(Enumerable.Range(1, numberOfDiscs).Reverse());
            PrintRods();
            MoveDiscs(numberOfDiscs, source, destination, spare);
        }

        private static void MoveDiscs(int bottomDisc, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisc == 1)
            {
                stepsTaken++;                
                destination.Push(source.Pop());
                Console.WriteLine("Step {0}: moved disk {1}", stepsTaken, bottomDisc);
                PrintRods();
            }
            else
            {
                //todo
                MoveDiscs(bottomDisc - 1, source, spare, destination);

                stepsTaken++;                
                destination.Push(source.Pop());
                Console.WriteLine("Step {0}: moved disk {1}", stepsTaken, bottomDisc);
                PrintRods();

                //todo
                MoveDiscs(bottomDisc - 1, spare, destination, source);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}
