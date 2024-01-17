using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace Heap_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] deadline = { 4, 4, 1, 2, 3, 4, 6 };
            int[] scores = { 60, 40, 20, 50, 30, 10, 5 };

            Console.WriteLine(Score(deadline, scores));
        }

        static int Score(int[] deadline, int[] score)
        {
            PriorityQueue<int, int> scores = new PriorityQueue<int, int>(); // 모든 과제 점수
            PriorityQueue<int, int> deadlines = new PriorityQueue<int, int>(); // 모든 과제 마감
            PriorityQueue<int, int> equals = new PriorityQueue<int, int>(); // 마감기한일이 남은 과제 
            int total = 0;
            /*int day = 1; // 잘못 생각한 문제
            for (int i = 0; i < deadline.Length; i++)
            {
                deadlines.Enqueue(deadline[i], deadline[i]);
            }
            for (int i = 0; i < score.Length; i++)
            {
                scores.Enqueue(score[i], deadline[i]);
            }
            while (scores.Count > 0)
            {
                while (true) // 마감일 확인용
                {
                    int nowDealine = deadlines.Dequeue(); // 지금과제 마감
                    if (day <= nowDealine)
                    {
                        if (day == nowDealine && deadlines.Peek() == nowDealine)
                        {
                            int nowScore = scores.Dequeue(); // 지금과제 점수
                            equals.Enqueue(nowScore, -nowScore);
                            while (day == nowDealine && deadlines.Peek() == nowDealine)
                            // 마감일 하고 지금 과제 같고, 다음과제도 마감일이 같을때 
                            {
                                int nextScore = scores.Dequeue(); // 다음과제 점수
                                deadlines.Dequeue();              // 다음과제 마감
                                equals.Enqueue(nextScore, -nextScore);
                            }
                            int filter = equals.Dequeue();
                            scores.Enqueue(filter, day);
                        }
                        break;
                    }
                    else
                    {
                        scores.Dequeue();
                    }
                }

                int sucess = scores.Dequeue();
                total += sucess;
                day++;
            }*/

            for (int i = 0; i < score.Length; i++)
            {
                scores.Enqueue(score[i], -deadline[i]);
            }
            for (int i = 0; i < deadline.Length; i++)
            {
                deadlines.Enqueue(deadline[i], -deadline[i]);
            }
            int day = deadlines.Peek();

            while (day > 0)
            {
                int nowDeadline = deadlines.Dequeue();
                if (nowDeadline >= day)
                {
                    if (deadlines.Count > 0 && day <= deadlines.Peek())
                    {
                        int nowScore = scores.Dequeue();
                        equals.Enqueue(nowScore, -nowScore);
                        while (deadlines.Count > 0 && day <= deadlines.Peek())
                        {
                            int nextDeadline = deadlines.Dequeue();
                            int nextScore = scores.Dequeue();
                            equals.Enqueue(nextScore, -nextScore);
                        }
                        scores.Enqueue(equals.Dequeue(), -day);
                    }
                    int sucees = scores.Dequeue();
                    total += sucees;
                    while (equals.Count > 0)
                    {
                        scores.Enqueue(equals.Dequeue(), -day);
                        deadlines.Enqueue(day, -day);
                    }

                }
                else
                {
                    deadlines.Enqueue(nowDeadline, -nowDeadline);
                }
                day--;
            }
            return total;
        }
    }
}
