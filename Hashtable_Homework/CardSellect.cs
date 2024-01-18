using System;
using System.Collections.Generic;
using System.Text;


namespace Hashtable_Homework
{
    class CardSellect
    {
        Dictionary<string, string> cards;

        public int TakeCard(int k)
        {
            int count = 0;

            // 몇가지 조합
            return count;
        }

        public void DropCard(string _value)
        {
            cards.Add(_value, _value);
        }

        public CardSellect()
        {
            cards = new Dictionary<string, string>();
        }
    }

    class prog
    {
        static void Main()
        {
            CardSellect cardSellect = new CardSellect();
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                cardSellect.DropCard(Console.ReadLine());
            }
            Console.WriteLine(cardSellect.TakeCard(k));
        }
    }
}
