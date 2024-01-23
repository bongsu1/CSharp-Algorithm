using System.Diagnostics;

namespace Search_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] graph = new bool[8, 8]
            {
                { false, false,  true, false,  true, false, false, false },
                { false, false,  true, false, false,  true, false, false },
                {  true,  true, false, false,  true, false,  true, false },
                { false, false, false, false, false, false, false, false },
                {  true, false,  true, false, false, false,  true, false },
                { false,  true, false, false, false, false, false, false },
                { false, false,  true, false, true, false, false,  true },
                { false, false, false, false, false, false,  true, false }
            };

            DFS(graph, 0, out bool[] visit, out int[] parent);
            Console.WriteLine("DFS graph   visit   parents");
            for (int i = 0; i < visit.Length; i++)
            {
                Console.WriteLine($"{i,7}{visit[i],10} {parent[i],7}");
            }
            Console.WriteLine();

            BFS(graph, 0, out bool[] visit2, out int[] parent2);
            Console.WriteLine("BFS graph   visit   parents");
            for (int i = 0; i < visit.Length; i++)
            {
                Console.WriteLine($"{i,7}{visit2[i],10} {parent2[i],7}");
            }
            Console.WriteLine();
        }
        // 3. 깊이 우선 탐색을 스택을 통해 구현하시오.
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            SearchNode(graph, start, visited, parents);
        }

        private static void SearchNode(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start, i] && !visited[i])
                {
                    parents[i] = start;
                    SearchNode(graph, i, visited, parents);
                }
            }
        }

        // 4. 너비 우선 탐색을 큐를 통해 구현하시오.
        public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Count > 0)
            {
                int next = queue.Dequeue();
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] && !visited[i])
                    {
                        visited[i] = true;
                        parents[i] = next;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
