using System.ComponentModel.Design;

namespace BinarySearchTree_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] players = { "mumu", "soe", "poe", "kai", "mine" };
            string[] callings = { "kai", "kai", "mine", "mine" };
            string[] result = solution(players, callings);
            foreach (string player in result)
            {
                Console.WriteLine(player);
            }
        }

        // 코테 달리기 경주
        /*// 배열을 쓰면 players와 callings의 데이터량이 많으면 탐색하는데 오래 걸린다
        static string[] solution(string[] players, string[] callings)
        {
            for (int i = 0; i < callings.Length; i++)
            {
                string call = callings[i];
                int rank = Array.IndexOf(players, call);
                string front = players[rank - 1];

                players[rank - 1] = call;
                players[rank] = front;
            }
            return players;
        }*/

        // 탐색하는데 용이한 이진탐색트리이용
        // players와 callings의 데이터량이 많을 때에도 배열을 이용한 탐색보다 빠르다
        static string[] solution(string[] players, string[] callings)
        {
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
            for (int i = 0; i < players.Length; ++i)
            {
                dict.Add(players[i], i);
            }

            for (int i = 0; i < callings.Length; ++i)
            {
                string call = callings[i];
                int rank = dict[call];
                string front = players[rank - 1];

                dict[call] = rank - 1;
                dict[front] = rank;

                players[rank - 1] = call;
                players[rank] = front;
            }
            return players;
        }
    }
}
