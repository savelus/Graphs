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

        public static int[,] ReadMatrix(string path)
        {
            StreamReader reader = new(path);
            var firstLine = reader.ReadLine();
            var intLine = GetIntLine(firstLine);
            int[,] matrix = new int[intLine.Length, intLine.Length];

            for (int j = 0; j < intLine.Length; j++)
            {
                matrix[0, j] = intLine[j];
            }
            for (int i = 1; i < intLine.Length; i++)
            {
                intLine = GetIntLine(reader.ReadLine());
                for (int j = 0; j < intLine.Length; j++)
                {
                    matrix[i,j] = intLine[j];
                }
            }
            reader.Close();
            return matrix;
        }
        private static int[] GetIntLine(string line)
        {
            var tempLine = line.Split(';');
            List<int> intLine = new();
            foreach (var number in tempLine)
            {
                if (int.TryParse(number, out int result))
                    intLine.Add(result);
            }
            return intLine.ToArray();
        }
    }
}
