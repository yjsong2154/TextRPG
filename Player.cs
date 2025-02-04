using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Player
    {
        private int Level { get; set; }
        private string Name { get; set; }
        private string Job { get; set; }
        private int Attack { get; set; }
        private int Defense { get; set; }
        private int Health { get; set; }
        private int Gold { get; set; }
        public Shop Shop { get; set; }

        public Player(int level = 1, string name = "Chad", string job = "전사", int attack = 10, int defense = 5, int health = 10, int gold = 1500) {
            Level = level;
            Name = name;
            Job = job;
            Attack = attack;
            Defense = defense;
            Health = health;
            Gold = gold;
            Shop  = new Shop();
        }

        public void EquipItem(int ItemNumber)
        {
            Shop.EquipItem(ItemNumber);
        }

        public void BuyItem(int ItemNumber)
        {
            int price = Shop.SellItem(ItemNumber, Gold);
            if (price > 0) 
            {
                Gold -= price;
            }
        }

        public void ReduceGold(int gold)
        {
            Gold -= gold;
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"Lv. {Level:00}");
            Console.WriteLine($"{Name} ( {Job} )");
            if (Shop.EquippedWeaponSum() == 0)
            {
                Console.WriteLine($"공격력 : {Attack}");
            }
            else
            {
                Console.WriteLine($"공격력 : {Attack + Shop.EquippedWeaponSum()} (+{Shop.EquippedWeaponSum()})");
            }
            if (Shop.EquippedArmorSum() == 0)
            {
                Console.WriteLine($"방어력 : {Defense}");
            }
            else
            {
                Console.WriteLine($"방어력 : {Defense + Shop.EquippedArmorSum()} (+{Shop.EquippedArmorSum()})");
            }
            Console.WriteLine($"체 력 : {Health}");
            Console.WriteLine($"Gold : {Gold} G");
        }

        public void ShowGold()
        {
            Console.WriteLine($"{Gold} G");
        }
    }
}
