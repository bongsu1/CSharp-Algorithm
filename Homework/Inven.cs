using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Item
    {
        protected string name;
        protected string info;
        protected int gold;

        public void Get()
        {
            Console.WriteLine($"{name}을 얻었습니다");
        }

        public void Throw()
        {
            Console.WriteLine($"{name}을 버립니다");
        }

        public void Render()
        {
            Console.WriteLine($"{name,-5} {info}\n가격 : {gold,5}");
        }
    }
    public class Weapon : Item
    {
        public Weapon(string _name, string _info, int _gold)
        {
            name = _name;
            info = _info;
            gold = _gold;
        }
    }
    public class Potion : Item
    {
        public Potion(string _name, string _info, int _gold)
        {
            name = _name;
            info = _info;
            gold = _gold;
        }
    }
    public class KeyItem : Item
    {
        public KeyItem(string _name, string _info, int _gold)
        {
            name = _name;
            info = _info;
            gold = _gold;
        }
    }
    public class Player
    {
        List<Item> inven = new List<Item>();
        public void RenderInven()
        {
            Console.Clear();
            Console.WriteLine("================인벤토리================");
            if (inven.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다");
                return;
            }
            for (int i = 0; i < inven.Count; i++)
            {
                inven[i].Render();
                Console.WriteLine();
            }
        }
        public void GetItem(Item item)
        {
            inven.Add(item);
            item.Get();
            item.Render();
        }

        public void ThrowItem(Item item)
        {
            item.Throw();
            inven.Remove(item);
        }
    }
    public class Inven
    {
        static void Main()
        {
            Player player = new Player();
            Weapon sword = new Weapon("낡은 검","날이 무뎌져 있다", 50);
            Weapon spear = new Weapon("연습용 창","나무로 되어 있다", 60);
            Potion redPotion = new Potion("빨간물약","약간 투명해서 반대쪽이 비친다", 10);
            KeyItem paperMap = new KeyItem("종이 지도", "어디든지 갈 수 있을것 같다", 0);

            player.GetItem(paperMap);
            player.GetItem(sword);
            player.GetItem(spear);
            player.GetItem(redPotion);

            player.ThrowItem(paperMap);
            player.ThrowItem(sword);
            player.ThrowItem(spear);

            player.RenderInven();
        }
    }
}
