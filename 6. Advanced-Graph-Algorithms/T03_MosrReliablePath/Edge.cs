using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_MosrReliablePath
{
    public class Edge
    {
        public Edge(Node endNode)
        {
            this.EndNode = endNode;
        }

        public Node EndNode { get; set; }
        public decimal Reliability { get; set; }
    }
}
