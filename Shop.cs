using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG
{
    public class Shop
    {
        private Item[] ItemList = new Item[6];
        public Shop()
        {
            ItemList[0] = new Item(name:"수련자 갑옷", armtype:0, status:5, manual: "수련에 도움을 주는 갑옷입니다.", price:1000, where:0);
            ItemList[1] = new Item(name: "무쇠갑옷", armtype: 0, status: 9, manual: "무쇠로 만들어져 튼튼한 갑옷입니다.", price: 2000, where: 2);
            ItemList[2] = new Item(name: "스파르타의 갑옷", armtype: 15, status: 5, manual: "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", price: 3500, where: 0);
            ItemList[3] = new Item(name: "낡은 검", armtype: 1, status: 2, manual: "쉽게 볼 수 있는 낡은 검 입니다.", price: 600, where: 1);
            ItemList[4] = new Item(name: "청동 도끼", armtype: 1, status: 5, manual: "어디선가 사용됐던거 같은 도끼입니다.", price: 1500, where: 0);
            ItemList[5] = new Item(name: "스파르타의 창", armtype: 1, status: 7, manual: "스파르타의 전사들이 사용했다는 전설의 창입니다.", price: 3000, where: 2);
        }

        public int SellItem(int ItemNumber, int Gold)
        {
            int price = ItemList[ItemNumber - 1].GetPrice();
            int ItemWhere = ItemList[ItemNumber - 1].GetWhere();

            if (ItemWhere == 1 || ItemWhere == 2)
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
                return -1;
            }
            else if (price > Gold)
            {
                Console.WriteLine("Gold가 부족합니다.");
                return -1;
            }
            else
            {
                Console.WriteLine("구매를 완료했습니다.");
                ItemList[ItemNumber - 1].SetWhere(1);
                return price;
            }
        }

        public void EquipItem(int ItemNumber)
        {
            int count = 0;
            for (int i = 0; i < ItemList.Length; i++)
            {
                if (ItemList[i].GetWhere() == 1 || ItemList[i].GetWhere() == 2)
                {
                    count++;
                    if (count == ItemNumber)
                    {
                        if(ItemList[i].GetWhere() == 1)
                        {
                            ItemList[i].SetWhere(2);
                        }
                        else
                        {
                            ItemList[i].SetWhere(1);
                        }
                        break;
                    }
                }
            }
        }

        public int EquippedArmorSum()
        {
            int armor = 0;
            foreach (Item item in ItemList)
            {
                if (item.GetWhere() == 2 && item.GetArmType() == 0 )
                {
                    armor += item.GetStatus();
                }
            }
            return armor;
        }

        public int EquippedWeaponSum()
        {
            int weapon = 0;
            foreach (Item item in ItemList)
            {
                if (item.GetWhere() == 2 && item.GetArmType() == 1 )
                {
                    weapon += item.GetStatus();
                }
            }
            return weapon;
        }

        public int ShowBuyedItem()
        {
            int total = 0;
            int number = 1;
            for (int i = 0; i < ItemList.Length; i++)
            {
                if (ItemList[i].GetWhere() == 1 || ItemList[i].GetWhere() == 2)
                {
                    total++;
                    ItemList[i].ShowItemEquipped(number);
                    number ++;
                }
            }
            return total;
        }

        public void ShowShopItem()
        {
            for (int i = 0; i < ItemList.Length; i++)
            {
                ItemList[i].ShowItemOnShop();
            }
        }

        public int ShowShopItemNumber ()
        {
            for (int i = 0; i < ItemList.Length; i++)
            {
                ItemList[i].ShowItemOnShop(i+1);
            }
            return ItemList.Length;
        }
    }
}
