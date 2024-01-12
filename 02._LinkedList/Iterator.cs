using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList
{
    internal class Iterator
    {
        void Main1()
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < 10; ++i)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }

            for (int i = 0; i < list.Count; ++i)
            {
                Console.Write($"{list[i]} ");
            }

            /*for (int i = 0; i < linkedList.Count; ++i)
            {
                Console.Write($"{linkedList[i]}"); // LinkedList는 index개념이 없음
            }*/

            for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
            {
                Console.Write($"{node.Value} ");
            }

            foreach (int value in list)
            {
                Console.Write($"{value}");
            }

            foreach (int value in linkedList)
            {
                Console.Write($"{value}");
            }

            /*Book book = new Book();
            foreach (string value in book)
            {

            }*/

            /*foreach (int value in Func())
            {

            }*/

            /*Average(list);
            Average(linkedList);*/
        }

        /*public class Book : IEnumerable<string>
        {
            public string[] text;

            public IEnumerator<string> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }*/

        /*public static IEnumerable<int> Func()
        {
            yield return 10;
            yield return 20;
            yield return 30;
            yield return 40;
            yield return 50;
        }*/

        /*public static float Average(IEnumerable<int> contaoner)
        {
            float average = 0;
            int count = 0;
            foreach (int value in contaoner)
            {
                average += value;
                count++;
            }
            return average / count;
        }*/
    }
}
