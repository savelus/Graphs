using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {
        private readonly List<Node> nodes = new();

        public void Add()
        {
            nodes.Add(new Node(nodes.Count));
        }
        public int Count => nodes.Count();
        public IEnumerable<Node> Nodes
        {
            get
            {
                foreach (var node in nodes) yield return node;
            }
        }
        public Node this[int index] { get { return nodes[index]; } }
        public int[,] ConvertToMatrix()
        {
            int[,] matrix = new int[nodes.Count, nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
            {
                foreach (var incidentNodes in nodes[i].IncidentNodes)
                {
                    matrix[i, incidentNodes.Item1.NodeNumber] = incidentNodes.Item2;
                }                
            }
            return matrix;
        }

        public Graph Clone()
        {
            Graph graph = new();
            foreach (var node in nodes)
            {
                graph.Add();
            }
            for (int i = 0; i < graph.Count; i++)
            {
                graph[i].isVisited = nodes[i].isVisited;
                foreach (var incidentNode in nodes[i].IncidentNodes)
                {
                    graph[i].AddIncidentNode(graph[incidentNode.Item1.NodeNumber], incidentNode.Item2);
                }
            }
            return graph;
        }
    }
    class Node
    {
        public readonly int NodeNumber;
        public bool isVisited;
        public Node(int Number)
        {
            NodeNumber = Number;
        }

        public  List<(Node, int)> incidentNodes = new();
        public void AddIncidentNode(Node node, int thickness)
        {
            incidentNodes.Add((node, thickness));
        }

        public (Node, int) this[int index] { get { return incidentNodes[index]; } }

        public IEnumerable<(Node, int)> IncidentNodes
        {
            get
            {
                foreach (var incidentNode in incidentNodes) yield return incidentNode;
            }
        }

        public override string ToString()
        {
            return NodeNumber.ToString();
        }
    }
}
