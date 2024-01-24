using System.Reflection.Metadata;

namespace Dijkstra_Homework
{
    internal class Program
    {
        const int INF = 99999;
        static void Main(string[] args)
        {
            int[,] graph = new int[18,18]
            {
                //  0    1    2    3    4    5    6    7    8    9   10   11   12   13   14   15   16   17
          /* 0*/{   0,   1,   7, INF,   4, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF },
          /* 1*/{   1,   0,   5, INF, INF,   2, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF },
          /* 2*/{   7,   5,   0,   9, INF,   3, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF },
          /* 3*/{ INF, INF,   9,   0, INF, INF,   8, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF },
          /* 4*/{   4, INF, INF, INF,   0, INF, INF,   3,   3, INF, INF, INF, INF, INF, INF, INF, INF, INF },
          /* 5*/{ INF,   2,   3, INF, INF,   0, INF, INF,   6,   8, INF, INF, INF, INF, INF, INF, INF, INF },
          /* 6*/{ INF, INF, INF,   8, INF, INF,   0, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF },
          /* 7*/{ INF, INF, INF, INF,   3, INF, INF,   0, INF, INF, INF,   8, INF, INF,   5, INF, INF, INF },
          /* 8*/{ INF, INF, INF, INF,   3,   6, INF, INF,   0,   6, INF,   5,   1, INF, INF, INF, INF, INF },
          /* 9*/{ INF, INF, INF, INF, INF,   8, INF, INF,   6,   0,   6, INF,   4,   2, INF, INF, INF, INF },
          /*10*/{ INF, INF, INF, INF, INF, INF, INF, INF, INF,   6,   0, INF, INF,   5, INF, INF, INF,   1 },
          /*11*/{ INF, INF, INF, INF, INF, INF, INF,   8,   5, INF, INF,   0,   9, INF,   1, INF, INF, INF },
          /*12*/{ INF, INF, INF, INF, INF, INF, INF, INF,   1,   4, INF,   9,   0,   8, INF,   8,   6, INF },
          /*13*/{ INF, INF, INF, INF, INF, INF, INF, INF, INF,   2,   5, INF,   8,   0, INF, INF, INF,   5 },
          /*14*/{ INF, INF, INF, INF, INF, INF, INF,   5, INF, INF, INF,   1, INF, INF,   0, INF, INF, INF },
          /*15*/{ INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   8, INF, INF,   0,   6,   2 },
          /*16*/{ INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   6, INF, INF,   6,   0, INF },
          /*17*/{ INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   1, INF, INF,   5, INF,   2, INF,   0 }
            };

            Dijkstra.ShortesPath(graph, 0, out bool[] visited, out int[] distance, out int[] parents);

            Console.WriteLine($"{"vertex",10}{"distance",10}{"parents",10}");
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.WriteLine($"{i,10}{distance[i],10}{parents[i],10}");
            }
        }
    }

    public class Dijkstra
    {
        public static void ShortesPath(int[,] graph, int start, out bool[] visited, out int[] distance, out int[] parents)
        {
            const int INF = 99999;

            int size = graph.GetLength(0);
            visited = new bool[size];
            distance = new int[size];
            parents = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                distance[i] = INF;
                parents[i] = -1;
            }

            distance[start] = 0;
            for (int i = 0; i < size; i++)
            {
                int next = -1;
                int minDistance = INF;
                for (int j = 0; j < size; j++)
                {
                    if (distance[j] < minDistance && !visited[j])
                    {
                        next = j;
                        minDistance = distance[j];
                    }
                }
                if (next < 0)
                    break;

                for (int j = 0; j < size; j++)
                {
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        parents[j] = next;
                    }
                }
                visited[next] = true;
            }
        }
    }
}
