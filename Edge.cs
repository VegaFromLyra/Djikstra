using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public class Edge
    {
        public Edge(Node startNode, Node endNode)
        {
            StartNode = startNode;
            EndNode = endNode;
        }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        public int Cost { get; set; }
    }
}
