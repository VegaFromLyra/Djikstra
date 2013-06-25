using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public class Node
    {
        // What is the equivalent of unsigned int in C# ?
        public int Distance { get; set; }

        public string Name { get; set; }

        public List<Node> Neighbors { get; set; }

        public List<Edge> Edges { get; set; }

        public bool IsVisited { get; set; } 

        public bool DoesEdgeExist(Node neighbor)
        {
            foreach (Edge edge in Edges)
            {
                if ((edge.EndNode == neighbor) || (edge.StartNode == neighbor))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
