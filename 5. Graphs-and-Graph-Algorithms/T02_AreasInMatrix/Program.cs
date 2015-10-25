using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_AreasInMatrix
{  
    class Program
    {
        static List<string>[] graph;
        static void Main(string[] args)
        {
            ReadGraph();
            // NEDOWYRSHENO!!!!
        }

        private static void ReadGraph()
        {
            int n = Int32.Parse(Console.ReadLine());
            graph = new List<string>[n];
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                graph[i] = new List<string>();
                for (int j = 0; j < line.Length; j++)
                {
                    //graph[j].Add(line[""]);
                }               
            }
        }
    }
}
