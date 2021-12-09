using System;

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
            gr[0].incidentNodes.Add((gr[1], 5));
        }
    }
}
