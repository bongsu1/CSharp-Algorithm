namespace _11._ShortesPath
{
    internal class Program
    {
        const int INF = 99999;
        static void Main(string[] args)
        {
            int[,] graph =
            {
                {   0,   9, INF,   1, INF, INF, INF, INF },
                {   9,   0, INF,   7, INF, INF,   4, INF },
                { INF, INF,   0, INF, INF, INF, INF, INF },
                {   1,   7, INF,   0, INF,   3, INF,   7 },
                { INF, INF, INF, INF,   0, INF,   4,   6 },
                { INF, INF, INF,   3, INF,   0, INF, INF },
                { INF,   4, INF, INF,   4, INF,   0, INF },
                { INF, INF, INF,   7,   6, INF, INF,   0 }
            };

            Dijkstra.ShortesPath(graph, 0,out bool[] visited, out int[] distance, out int[] parents);

            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, parents);
        }

        private static void PrintDijkstra(int[] distance, int[] parents)
        {
            Console.WriteLine($"{"Vertex",8}{"distance",10}{"Parents",8}");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write($"{i,8}");

                if (distance[i] >= INF)
                {
                    Console.Write($"{"INF",8}");
                }
                else
                {
                    Console.Write($"{distance[i],9}");
                }

                Console.WriteLine($"{parents[i],8}");
            }
        }
    }
}
