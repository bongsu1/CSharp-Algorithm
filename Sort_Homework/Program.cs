using System.Security.Cryptography;

namespace Sort_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> randomList = new List<int>();
            Random rand = new Random();

            Console.WriteLine("생성된 데이터 : ");
            for (int i = 0; i < 10; i++)
            {
                randomList.Add(rand.Next(0, 50));

                Console.Write($"{randomList[i],3}");
            }
            Console.WriteLine();

            Sort.QuickSort(randomList, 0, randomList.Count - 1);
            foreach (int value in randomList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }
    }

    public class Sort
    {
        // 1. 선택정렬
        public static void SelectionSort(List<int> list, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j <= end; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(list, minIndex, i);
            }
        }

        // 2. 삽입정렬
        public static void InsertionSort(List<int> list, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (list[j] >= list[j - 1])
                    {
                        break;
                    }
                    Swap(list, j, j - 1);
                }
            }
        }

        // 3.병합정렬
        public static void MergeSort(List<int> list, int start, int end)
        {
            if (start == end)
            {
                return;
            }

            int mid = (start + end) / 2 + 1;
            MergeSort(list, start, mid - 1);
            MergeSort(list, mid, end);
            Merge(list, start, mid, end);
        }

        static void Merge(List<int> list, int start, int mid, int end)
        {
            int left = start;
            int right = mid;
            List<int> sort = new List<int>();
            while (left < mid && right <= end)
            {
                if (list[left] > list[right])
                {
                    sort.Add(list[right]);
                    right++;
                }
                else
                {
                    sort.Add(list[left]);
                    left++;
                }
            }

            if (left < mid)
            {
                for (int i = left; i < mid; i++)
                {
                    sort.Add(list[left]);
                }
            }
            else if (right <= end)
            {
                for (int i = right; i <= end; i++)
                {
                    sort.Add(list[right]);
                }
            }

            for (int i = 0; i < sort.Count; i++)
            {
                list[start + i] = sort[i];
            }
        }

        // 4. 버블정렬
        public static void BubbleSort(List<int> list, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                for (int j = start; j < end - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }
        }

        // 5. 퀵 정렬
        public static void QuickSort(List<int> list, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = start;
            int left = start + 1;
            int right = end;
            while (left < right)
            {
                while (list[pivot] > list[left] && left < end)
                {
                    left++;
                }
                while (list[pivot] < list[right] && right > start)
                {
                    right--;
                }

                if (left < right)
                {
                    Swap(list, left, right);
                }
            }

            Swap(list, pivot, right);
            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }


        static void Swap(List<int> list, int leftIndex, int rightIndex)
        {
            int temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }
    }
}
