using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 사용자의 입력을 받아서 없는 데이터면 추가, 있던 데이터면 삭제하는 리스트
namespace Homework
{
    public class StarList<T>
    {
        private const int DefaultCapacity = 12;

        private T[] items;
        private int count;

        public StarList()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        public int Capacity
        {
            get { return items.Length; }
        }
        public int Count
        {
            get { return count; }
        }

        public T this[int index]
        {
            get 
            {
                if (index >= count)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
        }
        public void ControlClick(T item)
        {
            if (Remove(item))
            {
                Remove(item);
            }
            else
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                Console.WriteLine("더 이상 선택할 수 없습니다");
                return;
            }
            items[count++] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            --count;
            Array.Copy(items, index + 1, items, index, count - index);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; ++i)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

    }
    internal class Starcraft
    {
        static void Main()
        {
            StarList<int> squad = new StarList<int>();
            squad.ControlClick(1);
            squad.ControlClick(6);
            squad.ControlClick(7);
            squad.ControlClick(8);
            squad.ControlClick(3);
            squad.ControlClick(2);
            squad.ControlClick(7);
            squad.ControlClick(1);
            squad.ControlClick(6);
            squad.ControlClick(8);
        }
    }
}