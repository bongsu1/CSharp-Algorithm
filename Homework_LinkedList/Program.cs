// 1. 사용자의 입력으로 숫자를 입력 받아서 (마이너스도 허용)
// 2. 음수는 앞에 추가하고, 양수는 뒤에 추가하여
//    음수&양수를 반으로 나누는 연결리스트 구현
// 3. 입력 받을 때마다 처음부터 끝까지 출력 진행

using System.Numerics;

namespace Homework_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HalfList<int> list = new HalfList<int>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("주의!! 숫자만 입력하세요(0도 안됨)");
                Console.Write("숫자를 입력하세요 : ");
                int input;
                int.TryParse(Console.ReadLine(), out input);
                list.Input(input);

                Console.WriteLine();
                for (Node<int> node = list.First; node != null; node = node.Next)
                {
                    Console.Write($"{node.Value} ");
                }
                Console.WriteLine();
                Console.WriteLine("계속 진행하려면 아무키나 눌러주세요");
                Console.ReadKey();
            }
        }
    }

    public class HalfList<T> where T : IComparable
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public HalfList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        private void AddPlus(T _value)
        {
            Node<T> newNode = new Node<T>(_value);
            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                head.prev = newNode;
                newNode.next = head;
            }
            head = newNode;
            ++count;
        }

        private Node<T> AddMinus(T _value)
        {
            Node<T> newNode = new Node<T>(_value);
            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
            }
            tail = newNode;
            ++count;
            return newNode;
        }

        public void Input(T _value)
        {
            if (0.Equals(_value))
            {
                Console.WriteLine("입력하신 것은 넣을 수 없습니다");
            }
            else if (_value.CompareTo(0) > 0)
            {
                AddMinus(_value);
            }
            else
            {
                AddPlus(_value);
            }
        }

        public Node<T> First { get { return head; } }
        public Node<T> Last { get { return tail; } }
        public int Count { get { return count; } }
    }

    public class Node<T>
    {
        private T value;

        public Node<T> prev;
        public Node<T> next;

        public Node(T _value)
        {
            value = _value;
            prev = null;
            next = null;
        }

        public Node<T> Prev { get { return prev; } }
        public Node<T> Next { get { return next; } }

        public T Value { get { return value; } }
    }
}
