using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alquerque
{
    internal class MatrixGraph
    {
        private List<string> vertices = new();
        private int[,] adjacencyMatrix = new int[0, 0];

        public int VertexCount => vertices.Count;

        public IReadOnlyList<string> Vertices => vertices;

        private string Normalize(string label)
        {
            return label.Trim().ToLower(); // normalize to lowercase
        }

        public void AddVertex(string label)
        {
            label = Normalize(label);

            if (!vertices.Contains(label))
            {
                vertices.Add(label);
                ResizeMatrix(VertexCount);
            }
        }

        public void RemoveVertex(string label)
        {
            label = Normalize(label);
            int index = vertices.IndexOf(label);
            if (index == -1)
                throw new ArgumentException("Vertex not found.");

            vertices.RemoveAt(index);
            ResizeMatrix(VertexCount);
        }

        public void AddEdge(string from, string to)
        {
            from = Normalize(from);
            to = Normalize(to);

            if (from == to)
                throw new ArgumentException("Self-loops are not allowed.");

            // auto-add vertices if missing
            if (!vertices.Contains(from))
                AddVertex(from);
            if (!vertices.Contains(to))
                AddVertex(to);

            int i = vertices.IndexOf(from);
            int j = vertices.IndexOf(to);

            adjacencyMatrix[i, j] = 1;
            adjacencyMatrix[j, i] = 1; // undirected graph
        }

        public void RemoveEdge(string from, string to)
        {
            from = Normalize(from);
            to = Normalize(to);

            int i = vertices.IndexOf(from);
            int j = vertices.IndexOf(to);
            if (i == -1 || j == -1)
                throw new ArgumentException("Vertex not found.");

            adjacencyMatrix[i, j] = 0;
            adjacencyMatrix[j, i] = 0;
        }

        public bool HasEdge(string from, string to)
        {
            from = Normalize(from);
            to = Normalize(to);

            int i = vertices.IndexOf(from);
            int j = vertices.IndexOf(to);
            if (i == -1 || j == -1)
                return false;

            return adjacencyMatrix[i, j] != 0;
        }

        public List<string> GetNeighbors(string label)
        {
            label = Normalize(label);

            int index = vertices.IndexOf(label);
            if (index == -1)
                throw new ArgumentException("Vertex not found.");

            var neighbors = new List<string>();
            for (int j = 0; j < VertexCount; j++)
            {
                if (adjacencyMatrix[index, j] != 0)
                    neighbors.Add(vertices[j]);
            }
            return neighbors;
        }

        public void PrintMatrix()
        {
            Console.Write("   ");
            foreach (var v in vertices)
                Console.Write($"{v} ");
            Console.WriteLine();

            for (int i = 0; i < VertexCount; i++)
            {
                Console.Write($"{vertices[i]} ");
                for (int j = 0; j < VertexCount; j++)
                {
                    Console.Write($"{adjacencyMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private void ResizeMatrix(int newSize)
        {
            var newMatrix = new int[newSize, newSize];
            int minSize = Math.Min(newSize, adjacencyMatrix.GetLength(0));
            for (int i = 0; i < minSize; i++)
                for (int j = 0; j < minSize; j++)
                    newMatrix[i, j] = adjacencyMatrix[i, j];
            adjacencyMatrix = newMatrix;
        }
    }
}