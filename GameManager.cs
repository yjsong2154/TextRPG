using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG
{
    public class GameManager
    {
        private Player player;
        private int playerMove;

        public GameManager()
        {
            // 플레이어 객체 생성
            string playerName = "";
            playerName = GetName();
            player = new Player(name: playerName);
        }

        public void Run() {
            while (true)
            {
                ShowMainMenu();
                playerMove = ParseInput(Console.ReadLine());
                if (playerMove > 0)
                {
                    switch (playerMove)
                    {
                        case 1:
                            ShowStatuse();
                            break;
                        case 2:
                            ShowInventory(); 
                            break;
                        case 3:
                            ShowShop(); 
                            break;
                        default:
                            InputError();
                            break;
                    }
                }
                else
                {
                    InputError();
                }
            }
        }

        private string GetName()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 선택해 주세요.");
            string? playerName = Console.ReadLine();
            if (playerName == null)
            {
                return "스파르타";
            }
            else
            {
                return playerName;
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
        }

        private void ShowStatuse()
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine("");
                player.ShowPlayer();
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                choice = ParseInput(Console.ReadLine());
                if (choice != 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        private void ShowInventory()
        {
            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("");
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                choice = ParseInput(Console.ReadLine());

                if (choice == 1)
                {
                    ShowEquipped();
                }
                else if (choice != 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        private void ShowEquipped()
        {
            int choice = -1;
            int itemNum = -1;
            while (choice != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                itemNum = player.Shop.ShowBuyedItem();
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                choice = ParseInput(Console.ReadLine());

                if (choice < 0 || choice > itemNum)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else if (choice > 0)
                {
                    player.EquipItem(choice);
                }
            }
        }

        private void ShowShop()
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("");
                Console.WriteLine("[보유골드]");
                player.ShowGold();
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                player.Shop.ShowShopItem();
                Console.WriteLine("");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                choice = ParseInput(Console.ReadLine());

                if (choice == 1)
                {
                    ShowBuy();
                }
                else if (choice != 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        private void ShowBuy()
        {
            int choice = -1;
            int itemNum = -1;
            while (choice != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("");
                Console.WriteLine("[보유골드]");
                player.ShowGold();
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                itemNum = player.Shop.ShowShopItemNumber();
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                choice = ParseInput(Console.ReadLine());

                if (choice < 0 || choice > itemNum)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else if (choice > 0)
                {
                    player.BuyItem(choice);
                }
            }
        }

        private int ParseInput(string? inputText)
        {
            int result = 0;

            if(int.TryParse(inputText, out result))
            {
                return result;
            }

            return -1;
        }

        private void InputError()
        {
            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}
