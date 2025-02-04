using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Item
    {
        private string Name;
        private int ArmType; // 방어구 0, 무기 1
        private int Status;
        private string Manual;
        private int Price;
        private int Where; // 상점 : 0, 플레이어 : 1, 장비 : 2

        public Item(string name, int armtype, int status, string manual, int price, int where)
        {
            Name = name;
            ArmType = armtype;
            Status = status;
            Manual = manual;
            Price = price;
            Where = where;
        }

        public void SetWhere(int where)
        {
            Where = where;
        }

        public int GetWhere() { return Where; }

        public void ShowItemEquipped(int index)
        {
            string ShowType = ArmType == 0 ? "방어력" : "공격력";
            string isEquippeedString = Where == 2 ? "[E]" : "";
            Console.WriteLine($"- {index} {isEquippeedString}{Name} | {ShowType} +{Status} | {Manual}");
        }

        public int GetStatus() { return Status; }
        public int GetArmType() { return ArmType; }

        public void ShowItemOnShop()
        {
            string ShowType = ArmType == 0 ? "방어력" : "공격력";
            string isSelledString = (Where == 1 || Where == 2) ? "구매완료" : $"{Price} G";
            Console.WriteLine($"- {Name} | {ShowType} +{Status} | {Manual} | {isSelledString}");
        }

        public void ShowItemOnShop(int index)
        {
            string ShowType = ArmType == 0 ? "방어력" : "공격력";
            string isSelledString = (Where == 1 || Where == 2) ? "구매완료" : $"{Price} G";
            Console.WriteLine($"- {index} {Name} | {ShowType} +{Status} | {Manual} | {isSelledString}");
        }

        public int GetPrice() { return Price; }
    }
}
