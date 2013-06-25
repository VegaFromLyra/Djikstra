using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    class Program
    {

        const int INFINITY = -1;

        static void Main(string[] args)
        {
            string[] cityNames = {"Bombay", "Pune", "Goa", "Hydrebad" };

            Graph graph = new Graph();
            graph.Edges = new List<Edge>();
            graph.Nodes = new List<Node>();

            // First create nodes 
            foreach (string city in cityNames)
            {
                Node node = new Node();
                node.Neighbors = new List<Node>();
                node.Edges = new List<Edge>();
                node.Name = city;
                node.IsVisited = false;
                node.Distance = INFINITY;
                graph.Nodes.Add(node);
            }

            // Then assign neighbors to each node
            foreach (Node n in graph.Nodes)
            {
                n.Neighbors.AddRange(graph.GetNodesExceptGivenOne(n));
            }

            // Then intialize edges
            graph.IntializeEdges();

            // Do breadth first traversal

            graph.PerformBreadthFirstTraversal();
        }
    }
}
