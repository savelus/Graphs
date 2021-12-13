using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var gr = new Graph();
            gr.Add();
            gr.Add();
            gr.Add();
            gr[0].AddIncidentNode(gr[1], 1);
            gr[0].AddIncidentNode(gr[2], 2);
            //gr[1].AddIncidentNode(gr[0], 3);
            gr[2].AddIncidentNode(gr[1], 4);
            //FileWorker<bool>.SaveGraph("graph.csv", gr);
            //DepthTraversal(gr);
            //BreadthTraversal(gr);
            //int x = GetMaximumFlow(gr);

            var gr1 = Graph.ConvertToGraph(FileWorker.ReadMatrix("graph.csv"));
        }

        public static void DepthTraversal(Graph graph)
        {
            var tempGraph = graph.Clone();
            var nodeStack = new Stack<Node>();
            nodeStack.Push(tempGraph[0]);
            while (nodeStack.Count != 0)
            {
                var tempNode = nodeStack.Pop();
                tempNode.isVisited = true;
                //Место для отрисовки графа
                foreach (var incidentNode in tempNode.IncidentNodes)
                {
                    //вот тут можно показать какую вершину мы добавляем в стек
                    if (incidentNode.Item1.isVisited == true) continue;
                    nodeStack.Push(incidentNode.Item1);
                }
            }

        }

        public static void BreadthTraversal(Graph graph)
        {
            var tempGraph = graph.Clone();
            var nodeStack = new Queue<Node>();
            nodeStack.Enqueue(tempGraph[0]);
            while (nodeStack.Count != 0)
            {
                var tempNode = nodeStack.Dequeue();
                tempNode.isVisited = true;
                //Место для отрисовки графа
                foreach (var incidentNode in tempNode.IncidentNodes)
                {
                    //вот тут можно показать какую вершину мы добавляем в стек
                    if (incidentNode.Item1.isVisited == true) continue;
                    nodeStack.Enqueue(incidentNode.Item1);
                }
            }
        }

        public static int GetMaximumFlow(Graph graph)
        {
            var tempGraph = graph.Clone();
            int maxThickness = 0;
            while(true)
            {
                
                List<int> thicknesses = new();
                var tempNode = tempGraph[0];
                //Место для отрисовки графа
                if (tempNode.incidentNodes.Count == 0)
                    break;
                while (true)
                {
                    //Место для отрисовки графа
                    if (tempNode.incidentNodes.Count == 0)
                    {
                        tempNode = tempGraph[0];
                        break;
                    }
                    else
                    {
                        thicknesses.Add(tempNode.incidentNodes[0].Item2);
                        tempNode = tempNode.incidentNodes[0].Item1;
                    }
                }
                int minimumThickness = thicknesses.Min();
                maxThickness += minimumThickness;
                while (tempNode.incidentNodes.Count != 0)
                {
                    var tempIncidentNode = tempNode.incidentNodes[0];
                    tempNode.incidentNodes[0] = (tempIncidentNode.Item1, tempIncidentNode.Item2 - minimumThickness);
                    if(tempIncidentNode.Item2 - minimumThickness == 0)
                    {
                        tempNode.incidentNodes.RemoveAt(0);
                    }
                    tempNode = tempIncidentNode.Item1;
                }               
            }
            return maxThickness;
        }
    }
}
