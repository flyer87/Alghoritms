using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T01_ExtendCableNetwork
{
    class Program
    {
        //    static List<Edge> edges = new List<Edge>()
        //{
        //    new Edge("C", "D", 20),
        //    new Edge("D", "B", 2),
        //    new Edge("D", "E", 8),
        //    new Edge("I", "H", 7),
        //    new Edge("B", "A", 4),
        //    new Edge("C", "E", 7),
        //    new Edge("G", "H", 8),
        //    new Edge("I", "G", 10),
        //    new Edge("A", "D", 9),
        //    new Edge("E", "F", 12),
        //    new Edge("C", "A", 5)
        //};

        static HashSet<int> spanningTreeNodes = new HashSet<int>();
        static List<Edge> edges = new List<Edge>();
        static List<Edge> spannigTreeEdges = new List<Edge>();
        static int budget = 20;

        static void Main()
        {
            var graph = BuildGraph();

            // Start Prim's algorithm from each node not still in the spanning tree
            //foreach (var startNode in graph.Keys)
            //for (int startNode = 0; startNode < graph.Length; startNode++)
            //{
            //    if (!spanningTreeNodes.Contains(startNode))
            //        Prim(graph, spanningTreeNodes, startNode, spannngTreeEdges);
            //}

            Prim(graph, spanningTreeNodes, spannigTreeEdges);

            Console.WriteLine("Minimum spanning forest weight: " +
                spannigTreeEdges.Sum(e => e.Weight));
        }

        private static void Prim(List<Edge>[] graph,
            HashSet<int> spanningTreeNodes,
            List<Edge> spanningTreeEdges)
        {
            // Append the startNode child edges to the priority queue
            var priorityQueue = new BinaryHeap<Edge>();            
            foreach (var edge in spanningTreeEdges)
            {
                foreach (var childEdge in graph[edge.EndNode])
                {
                    priorityQueue.Enqueue(childEdge);                    
                }

                //foreach (var childEdge in graph[edge.EndNode])
                //{
                //    priorityQueue.Enqueue(childEdge);
                //}                
            }

            //spanningTreeNodes.Add(startNode);

            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();
                if ((spanningTreeNodes.Contains(smallestEdge.StartNode) ^
                    spanningTreeNodes.Contains(smallestEdge.EndNode)) )
                {
                    if ((budget - smallestEdge.Weight < 0))
                    {                                                
                        break;
                    }
                    budget -= smallestEdge.Weight;
                    Console.WriteLine("{{{0}, {1}}} -> {2}", smallestEdge.StartNode, 
                        smallestEdge.EndNode, smallestEdge.Weight  );

                    // Attach the smallest edge to the minimum spanning tree (MST)
                    spanningTreeEdges.Add(smallestEdge);
                    var nonTreeNode = spanningTreeNodes.Contains(smallestEdge.StartNode) ?
                        smallestEdge.EndNode : smallestEdge.StartNode;
                    spanningTreeNodes.Add(nonTreeNode);
                    foreach (var childEdge in graph[nonTreeNode])
                    {
                        priorityQueue.Enqueue(childEdge);
                    }
                }
            }
            Console.WriteLine("Budget left {0}", budget);
        }

        static List<Edge>[] BuildGraph()
        {            
            string line = Console.ReadLine();
            // get count of nodes
            int cntNodes = int.Parse(line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)[1]);
            var graph = new List<Edge>[cntNodes] ;

            line = Console.ReadLine();                              
            while (line != "end")
            {                
                string[] lineTokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // syzdawame edge
                var edge = new Edge(int.Parse(lineTokens[0]), int.Parse(lineTokens[1]), int.Parse(lineTokens[2]));
                edges.Add(edge);

                // create graph
                if (graph[edge.StartNode] == null)
                {
                    graph[edge.StartNode] = new List<Edge>();
                }
                graph[edge.StartNode].Add(edge);

                if (graph[edge.EndNode] == null)
                {
                    graph[edge.EndNode] = new List<Edge>();
                }
                graph[edge.EndNode].Add(edge);
                
                // connected
                if (lineTokens.Length > 3)
                {
                    // dobawqme w spanningTreeNodes 
                    if (!spanningTreeNodes.Contains(edge.StartNode))
                    {
                        spanningTreeNodes.Add(edge.StartNode);
                    }
                    // add in spanningTreeNodes
                    if (!spanningTreeNodes.Contains(edge.EndNode))
                    {
                        spanningTreeNodes.Add(edge.EndNode);
                    }
                    
                    spannigTreeEdges.Add(edge);
                }
                
                line = Console.ReadLine();                              
            }

            //budget
            return graph;
        }
    }
}
