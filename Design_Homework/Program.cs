using System;
using System.ComponentModel.DataAnnotations;

namespace Design_Homework
{
    public class Program
    {
        // 탐욕 ATM 완료
        static void Main()
        {
            PriorityQueue<int, int> que = new PriorityQueue<int, int>();

            int n = int.Parse(Console.ReadLine());
            string[] times = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                que.Enqueue(int.Parse(times[i]), int.Parse(times[i]));
            }

            int time = 0;
            int totalTime = 0;
            while (que.Count > 0)
            {
                time += que.Dequeue();
                totalTime += time;
            }
            Console.WriteLine(totalTime);
        }
    }
}
/*static void Main(string[] args)
{
    // 동적계획법 연속합
    int[] values = { 10, -4, 3, 1, 5, 6, -35, 12, 21, -1 };
    int max = int.MinValue;

    // [2, 4] : 2 ~ 4 더한값
    int[,] result = new int[values.Length, values.Length];

    for (int i = 0; i < values.Length; i++)
    {
        result[i, i] = values[i];
        if (max < values[i])
        {
            max = values[i];
        }
    }

    for (int start = 0; start < values.Length - 1; start++)
    {
        for (int end = start + 1; end < values.Length; end++)
        {
            result[start, end] = result[start, end - 1] + result[end, end];
            if (max < result[start, end])
            {
                max = result[start, end];
            }
        }
    }
    Console.WriteLine(max);
}*/

/*// 동적계획법 : 정수삼각형
static void Main()
{
    int n = int.Parse(Console.ReadLine());

    int total = 0;
    int big = 0;
    int bigIndex = 0;
    for (int i = 0; i < n; i++)
    {
        string[] pyramid = Console.ReadLine().Split(' ');

        for (int j = bigIndex; j < bigIndex + 2; j++)
        {
            if (big < int.Parse(pyramid[bigIndex]))
            {
                big = int.Parse(pyramid[bigIndex]);
            }
            if (pyramid.Length == 1) break;
        }
        total += big;
        bigIndex = Array.IndexOf(pyramid, big.ToString());
        big = 0;
    }
    Console.WriteLine(total);
}*/

/*// 백트래킹 : N과 M
static void Main()
{
    string[] nm = Console.ReadLine().Split(' ');
    int n = int.Parse(nm[0]);
    int m = int.Parse(nm[1]);

    for (int i = 0; i < n; i++)
    {

    }
}*/