using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_MosrReliablePath
{
    public class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public decimal ReliabilityFrmSource { get; set; }
        public Node PreviousNode { get; set; }

        int IComparable.CompareTo(object otherNode)
        {
            return this.ReliabilityFrmSource.CompareTo((otherNode as Node).ReliabilityFrmSource);
        }
    }
}
