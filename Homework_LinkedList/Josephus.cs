using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 4. 요세푸스 순열 문제
namespace Homework_LinkedList
{
    public class Josephus
    {
        static void Main()
        {
            LinkedList<int> Jose = new LinkedList<int>();

            int n;
            int k;

            Console.Write("참가하는 인원을 입력해주세요 : ");
            int.TryParse(Console.ReadLine(), out n);

            Console.Write("제거 할 순번 : ");
            int.TryParse(Console.ReadLine(), out k);

            for (int i = 1; i <= n; i++)
            {
                Jose.AddLast(i);
            }
            LinkedListNode<int> node = Jose.Last;
            while (Jose.Count != 0)
            {
                for (int i = 0; i < k; i++)
                {
                    node = node.next;
                }
                Console.Write($"{node.Value} ");
                Jose.Remove(node);
            }

            /*// 교수님 풀이
            LinkedList<int> josephus = new LinkedList<int>();

            int n;
            int k;

            Console.Write("참가하는 인원을 입력해주세요 : ");
            int.TryParse(Console.ReadLine(), out n);

            Console.Write("제거 할 순번 : ");
            int.TryParse(Console.ReadLine(), out k); 

            for (int i = 1; i <= n; i++)
            {
                josephus.AddLast(i);
            }

            while (josephus.Count > 0)
            {
                for(int i = 1; i <= k; i++)
                {
                    if(i == k)
                    {
                        LinkedListNode<int> node = josephus.First;
                        josephus.Remove(node);
                        Console.Write($"{node.Value}");
                    }
                    else
                    {
                        LinkedListNode<int> node = josephus.First;
                        josephus.Remove(node);
                        josephus.AddLast(node);
                    }
                }
            }*/
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }


        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (count == 0)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeAfter(tail, newNode);
            }
            return newNode;
        }

        public void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.prev = node;

            newNode.next = node.next;

            if (node == tail)
            {
                tail = newNode;
            }
            else
            {
                node.next.prev = newNode;
            }

            node.next = newNode;

            count++;
        }

        private void InsertNodeToEmptyList(LinkedListNode<T> newNode)
        {
            head = newNode;
            tail = newNode;
            newNode.prev = tail;
            newNode.next = head;
            count++;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> node = Find(value);
            if (node != null)
            {
                RemoveNode(node);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Remove(LinkedListNode<T> node)
        {
            RemoveNode(node);
        }
        public void RemoveFirst()
        {
            RemoveNode(head);
        }
        public void RemoveLast()
        {
            RemoveNode(tail);
        }

        public LinkedListNode<T> Find(T value)
        {
            for (LinkedListNode<T> node = First; node != null; node = node.Next)
            {
                if (value.Equals(node.Value))
                    return node;
            }
            return null;
        }

        private void RemoveNode(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }
    }

    public class LinkedListNode<T>
    {
        private T value;

        public LinkedListNode<T> prev;
        public LinkedListNode<T> next;

        public LinkedListNode(T value)
        {
            this.value = value;
            this.prev = null;
            this.next = null;
        }

        public LinkedListNode(T value, LinkedListNode<T> prev, LinkedListNode<T> next)
        {
            this.value = value;
            this.prev = prev;
            this.next = next;
        }

        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }

        public T Value { get { return value; } set { this.value = value; } }
    }
}
