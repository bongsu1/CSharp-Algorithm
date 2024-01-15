// 스택, 큐의 출력순서
// a. 추가(1, 2, 3, 4, 5), 모두 꺼내기 : 
// stack : 5, 4, 3, 2, 1
// queue : 1, 2, 3, 4, 5

// b. 추가(1,2,3), 꺼내기(2번), 추가(4,5,6), 꺼내기(1번), 추가(7), 모두꺼내기 : 
// stack : 3, 2, 6, 7, 5, 4, 1
// queue : 1, 2, 3, 4, 5, 6, 7

// c. 추가(3,2,1), 꺼내기(1번), 추가(6,5,4), 꺼내기(3번), 추가(9,8,7), 모두꺼내기 :
// stack : 1, 4, 5, 6, 7, 8, 9, 2, 3
// queue : 3, 2, 1, 6, 5, 4, 9, 8, 7

// d. 추가(1,3,5), 꺼내기(1번), 추가(2,4,8), 꺼내기(2번), 추가(1, 3), 모두꺼내기 : 
// stack : 5, 8, 4, 3, 1, 2, 3, 1
// queue : 1, 3, 5, 2, 4, 8, 1, 3

// e. 추가(3,2,1), 꺼내기(2번), 추가(3,2,1), 꺼내기(2번), 추가(3,2,1), 모두꺼내기 : 
// stack : 1, 2, 1, 2, 1, 2, 3, 3, 3
// queue : 3, 2, 1, 3, 2, 1, 3, 2, 1

using System.Diagnostics.CodeAnalysis;

namespace Stack_Queue_Homework
{
    internal class Program
    {
        // 2. 괄호 검사기
        static bool IsOk(string text)
        {
            Stack<char> textStack = new Stack<char>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '[' || text[i] == '{' || text[i] == '(')
                {
                    textStack.Push(text[i]);
                }
                else if (text[i] == ']' || text[i] == '}' || text[i] == ')')
                {
                    if (textStack.Count == 0) // 예외 처리 추가
                    {
                        return false;
                    }
                    switch (textStack.Peek())
                    {
                        case '[':
                            if (text[i] == ']')
                                textStack.Pop();
                            break;
                        case '{':
                            if (text[i] == '}')
                                textStack.Pop();
                            break;
                        case '(':
                            if (text[i] == ')')
                                textStack.Pop();
                            break;
                    }
                }
            }
            return textStack.Count == 0;
        }

        /*// 교수님 풀이
        static bool IsOk(string text)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in stack)
            {
                if (c == '[')
                {
                    stack.Push(c);
                }
                else if (c == '{')
                {
                    stack.Push(c);
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ']')
                {
                    if (stack.Count == 0)
                        return false;

                    char bracket = stack.Pop();
                    if (bracket == '[')
                    {
                        // 이건 괜찮은 상황
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (c == '}')
                {
                    if (stack.Count == 0)
                        return false;

                    char bracket = stack.Pop();
                    if (bracket == '}')
                    {
                        // 이건 괜찮은 상황
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                        return false;

                    char bracket = stack.Pop();
                    if (bracket == ')')
                    {
                        // 이건 괜찮은 상황
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (stack.Count > 0)
                return false;

            return true;
        }*/

        static void Main(string[] args)
        {
            //Console.WriteLine("괄호 검사기입니다 (괄호를 제대로 열고 닫으면 true가 출력됩니다)");
            string text = " ]"; //Console.ReadLine();
            Console.WriteLine(IsOk(text));

            int[] array = { 4, 4, 12, 10, 2, 10 };
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(ProcessJob(array)[i]);
            }
        }

        // 3. 작업 프로세스
        static int[] ProcessJob(int[] jobList)
        {
            int[] result = new int[jobList.Length];
            Queue<int> jobWork = new Queue<int>();
            for (int i = 0; i < jobList.Length; i++)
            {
                jobWork.Enqueue(jobList[i]);
            }

            int dayHours = 8;
            int day = 1;

            for (int i = 0; i < result.Length; i++)
            {
                while (true)
                {
                    if (dayHours >= jobWork.Peek())
                    {
                        dayHours -= jobWork.Peek();
                        result[i] = day;
                        jobWork.Dequeue();
                        break;
                    }
                    else
                    {
                        day++;
                        dayHours += 8;
                    }
                }
            }
            return result;
        }

        /*// 교수님 풀이
        public const int WorkTime = 8;
        static int[] ProcessJob(int[] jobList)
        {
            Queue<int> queue = new Queue<int>(jobList);
            int remainTime = 8;
            int day = 1;
            List<int> days = new List<int>();

            //for (int i = 0; i < jobList.Length; i++)
            //{
            //    queue.Enqueue(jobList[i]);
            //}

            while (queue.Count > 0)
            {
                int WorkTime = queue.Dequeue();
                while (true)
                {
                    if (WorkTime <= remainTime)
                    {
                        remainTime -= WorkTime;
                        // 작업 완료
                        days.Add(day);
                        break;
                    }
                    else
                    {
                        WorkTime -= remainTime;
                        // 다음날로
                        day++;
                        remainTime = 8;
                    }
                }
            }
            return days.ToArray();
        }*/
    }
}
