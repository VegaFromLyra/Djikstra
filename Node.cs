using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public class Node : IComparable
    {
        private string _name;

        public Node(string name)
        {
            _name = name;
        }
        // What is the equivalent of unsigned int in C# ?
        public int Distance { get; set; }

        public string Name 
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public List<Node> Neighbors { get; set; }

        public List<Edge> Edges { get; set; }

        public Node Previous { get; set; }

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

        public int CompareTo(object other)
        {
            Node otherNode = other as Node;

            if (this.Distance < otherNode.Distance)
            {
                return -1;
            }
            else if (this.Distance > otherNode.Distance)
            {
                return 1;
            }

            return 0;
        }
    }
}
