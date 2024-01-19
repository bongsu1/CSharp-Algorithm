using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;


namespace Hashtable_Homework
{
    class CardSellect
    {
        Dictionary<int, string> cards;
        SortedSet<string> combination = new SortedSet<string>();
        public int TakeCard(int take)
        {
            switch (take)
            {
                case 2:
                    for (int i = 0; i < cards.Count; i++)
                    {
                        for (int j = 0; j < cards.Count; j++)
                        {
                            if (i == j) continue;
                            combination.Add($"{cards[i]}{cards[j]}");
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < cards.Count; i++)
                    {
                        for (int j = 0; j < cards.Count; j++)
                        {
                            for (int k = 0; k < cards.Count; k++)
                            {
                                if (i == j || j == k || i == k) continue;
                                combination.Add($"{cards[i]}{cards[j]}{cards[k]}");
                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < cards.Count; i++)
                    {
                        for (int j = 0; j < cards.Count; j++)
                        {
                            for (int k = 0; k < cards.Count; k++)
                            {
                                for (int r = 0; r < cards.Count; r++)
                                {
                                    {
                                        if (i == j || j == k || i == k || i == r || j == r || k == r) continue;
                                        combination.Add($"{cards[i]}{cards[j]}{cards[k]}{cards[r]}");
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            return combination.Count;
        }
        public void DropCard(string _value, int count)
        {
            cards.Add(count, _value);
        }

        public CardSellect()
        {
            cards = new Dictionary<int, string>();
        }
    }

    class prog
    {
        static void Main()
        {
            CardSellect cardSellect = new CardSellect();
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                cardSellect.DropCard(Console.ReadLine(), count);
                count++;
            }
            Console.WriteLine(cardSellect.TakeCard(k));
        }
    }
}
