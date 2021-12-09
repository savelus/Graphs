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
            nodes.Add(new Node(nodes.Count + 1));
        }
        public int Count => nodes.Count();
        public IEnumerable<Node> Nodes
        {
            get
            {
                foreach (var node in nodes) yield return node;
            }
        }

    }
    class Node
    {
        public readonly int NodeNumber;
        public Node(int Number)
        {
            NodeNumber = Number;
        }
        public List<Tuple<Node, int>> incidentNodes = new();
        public IEnumerable<Tuple<Node, int>> IncidentNodes
        {
            get
            {
                foreach (var incidenNode in incidentNodes) yield return incidenNode;
            }
        }
    }
}
