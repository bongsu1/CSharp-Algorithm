using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A+ 풍선 터트리기
namespace _Homework_LinkedList
{
    internal class Balloon
    {
        static void Main()
        {
            LinkedList<int> balloon = new LinkedList<int>();
            Random rnd = new Random();

            int n;
            Console.Write("풍선 갯수를 입력해 주세요 : ");
            int.TryParse(Console.ReadLine(), out n);

            for (int i = 1; i <= n; i++)
            {
                balloon.AddLast(i);
            }

            while (balloon.Count > 0)
            {
                int k = rnd.Next(-n, n);
                if (k > 0)
                {
                    for (int i = 1; i <= k; i++)
                    {
                        if(i == k)
                        {
                            LinkedListNode<int> node = balloon.First;
                            Console.Write($"{node.Value} ");
                            balloon.Remove(node);
                        }
                        else
                        {
                            LinkedListNode<int> node = balloon.First;
                            balloon.Remove(node);
                            balloon.AddLast(node);
                        }
                    }
                }
                else if (k < 0)
                {
                    for (int i = -1; i >= k; i--)
                    {
                        if (i == k)
                        {
                            LinkedListNode<int> node = balloon.Last;
                            Console.Write($"{node.Value} ");
                            balloon.Remove(node);
                        }
                        else
                        {
                            LinkedListNode<int> node = balloon.Last;
                            balloon.Remove(node);
                            balloon.AddFirst(node);
                        }
                    }

                }
            }
        }
    }
}