using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class FileWorker
    {
        public static void SaveGraph(string path, Graph graph)
        {
            StreamWriter writer = new(path);
            var matrix = graph.ConvertToMatrix();
            for (int i = 0; i < graph.Count; i++)
            {
                StringBuilder sb = new();
                for (int j = 0; j < graph.Count; j++)
                {
                    sb.Append(matrix[i, j].ToString() + ";");
                }
                writer.WriteLine(sb.ToString());
            }
            writer.Close();
        }
    }
}
