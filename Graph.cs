using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }

        public List<Edge> Edges { get; set; }

        public Node FindNode(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Node> GetNodesExceptGivenOne(Node n)
        {

            if (Nodes == null)
            {
                throw new Exception("Error occured since Nodes are null");
            }

            List<Node> result = new List<Node>();
            foreach (Node node in Nodes)
            {
                if (node != n)
                {
                    result.Add(node);
                }
            }

            return result;
        }

        public void IntializeEdges()
        {
            if (Nodes == null)
            {
                throw new Exception("Nodes cannot be null when edges have to be initialized");
            }

            foreach (Node n in Nodes)
            {
                foreach (Node neighbor in n.Neighbors)
                {
                    if (!n.DoesEdgeExist(neighbor))
                    {
                        Edge edge = new Edge(n, neighbor);
                        Edges.Add(edge);
                        n.Edges.Add(edge);
                        neighbor.Edges.Add(edge);
                    }
                }
            }
        }

        // Currently prints traversed nodes to console
        public void PerformBreadthFirstTraversal()
        {
            Queue<Node> queueNodes = new Queue<Node>();
              
            queueNodes.Enqueue(Nodes[0]);
            Nodes[0].IsVisited = true;

            while (queueNodes.Count > 0)
            {
                Node currentNode = queueNodes.Dequeue();
                System.Console.WriteLine(currentNode.Name);                
                foreach (Node n in currentNode.Neighbors)
                {
                    if (n.IsVisited == false)
                    {
                        queueNodes.Enqueue(n);
                        n.IsVisited = true;
                    }
                }
            }
        }


    }
}
