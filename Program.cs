using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    class Program
    {
        static void InitializeEdgeCost(Graph graph, string startNodeName, string endNodeName, int cost)
        {
            Edge edge = graph.FindEdge(new Node(startNodeName), new Node(endNodeName));
            if (edge == null)
            {
                throw new Exception("Error! Edge is not present in graph");
            }
            edge.Cost = cost;
        }

        static void Main(string[] args)
        {
            string[] cityNames = {"Bombay", "Pune", "Goa", "Hydrebad" };

            Graph graph = new Graph();
            graph.Edges = new List<Edge>();
            graph.Nodes = new List<Node>();

            // First create nodes 
            foreach (string city in cityNames)
            {
                Node node = new Node(city);
                node.Neighbors = new List<Node>();
                node.Edges = new List<Edge>();
                node.IsVisited = false;
                node.Distance = Constants.INFINITY;
                graph.Nodes.Add(node);
            }

            // Then assign neighbors to each node
            foreach (Node n in graph.Nodes)
            {
                n.Neighbors.AddRange(graph.GetNodesExceptGivenOne(n));
            }

            // Then intialize edges
            graph.IntializeEdges();

            // Intialize cost of Edges
            InitializeEdgeCost(graph, "Bombay", "Pune", 5);
            InitializeEdgeCost(graph, "Pune", "Bombay", 5);
            InitializeEdgeCost(graph, "Bombay", "Goa", 3);
            InitializeEdgeCost(graph, "Goa", "Bombay", 3);
            InitializeEdgeCost(graph, "Bombay", "Hydrebad", 60);
            InitializeEdgeCost(graph, "Hydrebad", "Bombay", 60);
            InitializeEdgeCost(graph, "Pune", "Hydrebad", 30);
            InitializeEdgeCost(graph, "Hydrebad", "Pune", 30);
            InitializeEdgeCost(graph, "Goa", "Hydrebad", 10);
            InitializeEdgeCost(graph, "Hydrebad", "Goa", 10);
            InitializeEdgeCost(graph, "Pune", "Goa", 25);
            InitializeEdgeCost(graph, "Goa", "Pune", 25);

            // Do breadth first traversal
            // graph.PerformBreadthFirstTraversal();

            Node origin = graph.FindNode("Bombay");
            if (origin == null)
            {
                throw new Exception("Origin is null");
            }

            Node destination = graph.FindNode("Hydrebad");
            if (destination == null)
            {
                throw new Exception("Destination is null");
            }

            List<Node> shortestPath = graph.FindShortestPath(origin, destination);

            System.Console.WriteLine("The shortest path from " + origin.Name + " to " + destination.Name);
            foreach (Node n in shortestPath)
            {
                System.Console.WriteLine(n.Name);
            }   
        }
    }
}
   