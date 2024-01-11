// 1. 사용자에세 숫자를 입력 받아서
// 2. 0부터 ~숫자까지 가지는 리스트 만들기
// 3. 0요소를 제거
// 4. 리스트가 가지는 모든 요소들을 출력해주는 반복문 작성
namespace Homework
{
    public class MyList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int count;

        public MyList()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }
        public MyList(int capacity)
        {
            items = new T[capacity];
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

        public void Add(T item)
        {
            if (count == items.Length)
                Grow();

            items[count++] = item;
        }

        private void Grow()
        {
            T[] newItems = new T[items.Length * 2];
            Array.Copy(items, newItems, count);
            items = newItems;
        }

        public void Insert(int index, T item)
        {
            if (index > count)
                throw new IndexOutOfRangeException();
            if (count == items.Length)
                Grow();

            Array.Copy(items, index, items, index + 1, count - index);
            items[index] = item;
            ++count;
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
    internal class Program
    {
        static void Main1(string[] args)
        {
            MyList<string> strList = new MyList<string>();

            strList.Add("0번째 추가");
            strList.Add("1번째 추가");
            strList.Add("2번째 추가");
            strList.Add("3번째 추가");
            strList.Add("4번째 추가");
            strList.Add("5번째 추가");
            strList.Add("6번째 추가");
            strList.Add("7번째 추가");

            bool fail = strList.Remove("8번째 추가"); // false
            bool comp = strList.Remove("4번째 추가"); // true

            strList.Insert(4, "4번째로 인서트");
            strList.Insert(6, "6번째로 인서트");

            int index1 = strList.IndexOf("6번째 추가");
            int index2 = strList.IndexOf("7번째 추가");

            strList.RemoveAt(7);

            strList.Add("끝에 추가");
            strList.RemoveAt(0);
            
            for (int i = 0; i < strList.Count; ++i)
            {
                Console.WriteLine(strList[i]);
            }
        }
    }

}