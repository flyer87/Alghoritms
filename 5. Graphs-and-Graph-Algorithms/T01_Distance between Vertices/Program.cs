using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_Distance_between_Vertices
{
    class NodeParent
    {
        public int currentNode;
        public NodeParent parentNode;
    }

    class Program
    {                  
        static Dictionary<int, List<int>> graph = new Dictionary<int,List<int>>();
        static HashSet<int> visitedNodes = new HashSet<int>();

        static int startNode = 5;
        static int searchedNode = 6;
        static int length = -1;

        static void Main(string[] args)
        {
            ReadGraph();
            BFS(startNode, searchedNode);
            Console.WriteLine("Length: {0}", length);
        }

        private static void BFS(int startNode, int endNode)
        {
            Queue<NodeParent> queue = new Queue<NodeParent>();

            queue.Enqueue(new NodeParent { currentNode = startNode, parentNode = null });
            while (queue.Count > 0)
            {
                NodeParent node = queue.Dequeue();
                if (!visitedNodes.Contains(node.currentNode))
                {
                    if (node.currentNode == endNode)
                    {
                        CalculateLenght(node);
                        break;
                    }

                    foreach (var child in graph[node.currentNode])
                    {
                        queue.Enqueue(new NodeParent
                        {
                            currentNode = child,
                            parentNode = node
                        }
                       );
                    }
                }
            }
        }

        private static void CalculateLenght(NodeParent node)
        {
            while (node.parentNode != null)
            {
                length++;
                node = node.parentNode;
            }

            length++;// zashtoto pochwame ot -1
        }

        private static void ReadGraph()
        {
            string line = Console.ReadLine().Trim();
            bool hasMoreNodes;
            do
            {                
                int num;
                if (Int32.TryParse((line[0]).ToString(), out num))
                {
                    int[] nodesAsInt = line.Split(new char[] { '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries).
                        Select(Int32.Parse).ToArray();

                    if (!graph.ContainsKey(nodesAsInt[0]))
                    {
                        graph[nodesAsInt[0]] = new List<int>();
                    }

                    for (int i = 1; i < nodesAsInt.Length; i++)
                    {
                        graph[nodesAsInt[0]].Add(nodesAsInt[i]);
                    }
                }

                line = Console.ReadLine().Trim();
                hasMoreNodes = Int32.TryParse((line[0]).ToString(), out num);
            } while (hasMoreNodes);
        }
    }

}
