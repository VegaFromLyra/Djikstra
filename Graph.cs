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
            foreach (Node n in Nodes)
            {
                if (n.Name == Name)
                {
                    return n;
                }
            }

            return null;
        }

        public Node FindNode(Node node)
        {
            return FindNode(node.Name);
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
                    Edge edge = new Edge(n, neighbor);
                    Edges.Add(edge);
                    n.Edges.Add(edge);
                    neighbor.Edges.Add(edge);
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

        void UpdateGraphWithDistancesFromNode(Node source)
        {
            PriorityQueue<Node> unVisitedNodes = new PriorityQueue<Node>(Nodes); // Time to create a min heap - O(n)

            // Does this update the value of 'source' in Nodes ?
            source.Distance = 0;

            while (!unVisitedNodes.Empty()) // O(n)
            {
                Node current = unVisitedNodes.Peek();

                if (current.Distance == Constants.INFINITY)
                {
                    break;
                }

                foreach (Node neighbor in current.Neighbors) // O(nm)
                {
                    if (unVisitedNodes.Contains(neighbor))
                    {
                        int tentative = 0;
                        Edge edge = FindEdge(current, neighbor);  // O(nml)
                        tentative = current.Distance + edge.Cost;
                        if (tentative < neighbor.Distance)
                        {
                            neighbor.Distance = tentative;
                            neighbor.Previous = current;
                        }
                    }
                }

                unVisitedNodes.Dequeue();
            }
        }

        List<Node> FindShortestPath(Node destination)
        {
            if (destination == null)
            {
                throw new Exception("Error occured: Destination is null");
            }

            Node current = destination.Previous;

            Stack<Node> resultReverse = new Stack<Node>();
            resultReverse.Push(destination);

            while (current != null)
            {
                resultReverse.Push(current);
                current = current.Previous;
            }

            List<Node> result = new List<Node>();

            while (resultReverse.Count > 0)
            {
                result.Add(resultReverse.Pop());
            }

            return result;
        }

        // Time complexity ?

        public List<Node> FindShortestPath(Node source, Node destination)
        {
            if (FindNode(source) == null)
            {
                throw new Exception("Source node is not present in the graph");
            }

            if (FindNode(destination) == null)
            {
                throw new Exception("destination node is not present in graph");
            }

            UpdateGraphWithDistancesFromNode(source);
            return FindShortestPath(destination);
        }

        public Edge FindEdge(Node startNode, Node endNode)
        {
            foreach (Edge edge in Edges)
            {
                if ((edge.StartNode.Name == startNode.Name) && (edge.EndNode.Name == endNode.Name))
                {
                    return edge;
                }
            }

            return null;
        }
    }
}
