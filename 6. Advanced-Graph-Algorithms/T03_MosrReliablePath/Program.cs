using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_MosrReliablePath
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new List<Edge>[15];
            // add reliability from source Node
            

        }

        private void DijkstraAlgorithm(List<Edge>[] graph, Node startNode, Node endNode)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();
            startNode.ReliabilityFrmSource = 0.0m;
            queue.Enqueue(startNode);

            
            while (true)
            {
                Node currentNode = queue.Dequeue();
                for (int i = 0; i < graph[currentNode.Id].Count; i++)
                {
                    graph[currentNode.Id][i];
                }
            }
        }
    }
}
