using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_CyclesInGraph
{
    class Program
    {
        static private Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        static HashSet<string> visited = new HashSet<string>();
        static HashSet<string> cycles = new HashSet<string>();
        static bool isACyclic = true;

        static void Main(string[] args)
        {
            ReadGraph();
            foreach (var key in graph.Keys)
            {
                CheckForCyclesDFS(key);
            }

            Console.WriteLine("Acyclic: {0}", isACyclic == true ? "Yes" : "No");
        }

        private static void CheckForCyclesDFS(string node)
        {
            if (cycles.Contains(node))
            {
                isACyclic = false;
            }

            if (!visited.Contains(node))
            {
                visited.Add(node);
                
                if (graph.ContainsKey(node))
                {
                    cycles.Add(node);
                    foreach (var childNode in graph[node])
                    {
                        CheckForCyclesDFS(childNode);
                    }
                    cycles.Remove(node);
                }
            }
        }

        private static void ReadGraph()
        {
            string line = Console.ReadLine();
            while (!String.IsNullOrEmpty(line))
            {
                string[] nodes = line.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!graph.ContainsKey(nodes[0]))
                {
                    graph[nodes[0]] = new List<string>();
                }
                graph[nodes[0]].Add(nodes[1]);

                line = Console.ReadLine();
            }
        }
    }
}
