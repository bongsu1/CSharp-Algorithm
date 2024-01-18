namespace Hashtable_Homework
{
    // 스타크래프트 치트키
    public class CheatKey
    {
        private Dictionary<string, Action> cheatDic;

        public void Run(string cheatKey)
        {
            cheatDic.TryGetValue(cheatKey, out Action OnCheat);
            OnCheat?.Invoke();
        }

        private void ShowMeTheMoney()
        {
            Console.WriteLine("자원을 늘려주는 치트키 발동!");
        }

        private void TrereIsNoCowLevel()
        {
            Console.WriteLine("바로 승리합니다 치트키 발동!");
        }

        public CheatKey()
        {
            cheatDic = new Dictionary<string, Action>();
            cheatDic.Add("ShowMeTheMoney", ShowMeTheMoney);
            cheatDic.Add("ThereIsNoCowLevel", TrereIsNoCowLevel);
        }
    }

    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.Clear();
            Console.WriteLine("치트를 입력해주세요");
            string input = Console.ReadLine();
            CheatKey cheatKey = new CheatKey();
            cheatKey.Run(input);
            Console.ReadKey();
        }
    }
}
