using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using static textRPG.Program;

namespace textRPG
{
    internal class Program
    {

        static Player user = new Player();

        static Weapon sword = new Weapon { name = "숏소드", attack = 3 ,isEquipped = false,buy = true,price = 100};
        static Weapon axe = new Weapon { name = "손 도끼", attack = 5, isEquipped = false,buy = false ,price = 700};
        static Armor shirt = new Armor { name = "모험가의 셔츠", defense = 4 ,isEquipped = false,buy = true,price = 400};
        static Armor huntershirt = new Armor { name = "사냥꾼의 셔츠", defense = 8, isEquipped = false,buy =false ,price = 2000};


        static List<Item> inventory = new List<Item>();
        static List<Item> store = new List<Item>();

 




        public class Player
        {
            private int level = 1;
            public string playerName { get;set; }
            public string job { get; set; }
            public int defense{ get; set; }
            public int hp { get; set; }
            public int gold { get; set; }
            public int attack { get; set; }


            //아이템이 장착 된 수치 값
            //추가될 무기 공격력 
            public int userWeapon = 0;
            //추가될 방어구 방어력
            public int userArmor = 0;




            public void Playerstat()
            {
                Console.WriteLine("Lv :"+level);
                Console.WriteLine("닉네임 :" + playerName);
                Console.WriteLine("직업 :"+job);

                if(userWeapon != 0)
                {
                    Console.WriteLine($"공격력 : {attack} + {userWeapon}");
                }
                else
                {
                    Console.WriteLine("공격력 :" + attack);
                }

                if (userArmor != 0)
                {
                    Console.WriteLine($"방어력 : {defense} + {userArmor}");
                }
                else
                {
                    Console.WriteLine("방어력 :" + defense);
                }

                Console.WriteLine("체력 :"+ hp);
            }

        }


        public class Item
        {
            public string name { get; set; }
            public bool isEquipped { get; set; }
            public bool buy { get; set; }
            public int price { get; set; }
        }
        public class Weapon:Item
        {
            public int attack { get; set; }

        }

        public class Armor:Item
        {
            public int defense { get; set; }
        }


        static void Main(string[] args)
        {
            Console.Write("당신의 이름을 입력해주세요. : ");
            //유저 기본값
            user.playerName = Console.ReadLine();
            user.job = "모험가";
            user.defense = 8;
            user.hp = 100;
            user.gold = 1500;
            user.attack = 3;


            //초기 지급 장비
            inventory.Add(shirt);
            inventory.Add(sword);


            //상점 물품 목록
            store.Add(axe);
            store.Add(huntershirt);


            Gamemenu();

        }

        static void Gamemenu()
        {
            
            bool end = false;
            do
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할수있습니다.");

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 종료");

                Console.Write("원하시는 행동을 입력해주세요. : ");

               
                if (int.TryParse(Console.ReadLine(), out int choice))
                //숫자 입력시 숫자를 choice 변수에 저장 
                {
                    switch (choice)
                    //입력된 숫자의 따라 결과확인
                    {
                        case 1:
                            Console.Clear();
                           
                            user.Playerstat();
                            statmeun();
                            break;
                        case 2:
                            Console.Clear();

                            Inventorymeun();
                            break;
                        case 3:

                            Console.Clear();

                            Store();
                            break;
                        case 4:
                            end = true;
                            break;
                    }

                }
            } while (end == false);
        }
        static void statmeun()
        {
            bool menuBack = false;
             do
             { 
                
                Console.WriteLine("1. 메인 메뉴로");
                Console.Write("원하시는 행동을 입력해주세요. : ");
                if ((Console.ReadLine()) == "1")
                {
                    menuBack = true;
                }

             }while (menuBack == false);
        }

        //인벤토리 구역
        static void Inventorymeun()
            //보유 중인 아이템 목록
        {
            Console.Clear();

            bool menuBack = false;
            do
            {
                Console.WriteLine("[아이템 목록]");

                Console.WriteLine();

                Console.WriteLine("보유 골드 :" + user.gold);

                foreach ( Item item in inventory)
                //아이템 클래스의 정보를item변수에 넣고 inventory 리스트로넣는다
                {
                    Console.WriteLine();
                    if (item is Weapon weapon)
                    //item 이라는 변수안에 Weapon클래스의 weapon이라는객체일때 작동
                    //창착시 [E] 표시 추가하기
                    {
                        if (weapon.isEquipped)
                        {
                            Console.WriteLine($"[E] {item.name} || 공격력 {weapon.attack}");
                           
                        }
                        else
                        {
                            Console.WriteLine($"{item.name} || 공격력 {weapon.attack}");
                        }
                    }
                    else if (item is Armor armor)
                    {
                        
                        if(armor.isEquipped)
                        {
                            Console.WriteLine($"[E]{item.name} || 방어력 {armor.defense}");
                            
                        }
                        else
                        {
                            Console.WriteLine($"{item.name} || 방어력 {armor.defense}");
                        }
                        
                    }
                    
                }
                Console.WriteLine("2. 장착관리");
                Console.WriteLine("1. 메인 메뉴로");
                Console.Write("원하시는 행동을 입력해주세요. : ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            menuBack = true;
                            break;
                        case 2:
                            Equipmeun();
                            break;

                    }              
                }

            } while (menuBack == false);
        }

        static void Equipmeun()
        {

            Console.Clear();

            int choiceindex = 1;
            foreach (Item item in inventory)
                //inventory 리스트중 Item 클래스 객체정보를 item 이라는 변수에 넣는다
                {
                    Console.WriteLine();
                    if (item is Weapon weapon)
                    //Weapon클래스 weapon 변수 로 지정
                    //item 이라는 변수안에 Weapon클래스의 객체일때 작동
                    //창착시 [E] 표시 추가하기
                    {

                        Console.WriteLine($"{choiceindex}. {item.name} || 공격력 {weapon.attack}");
                       
                    }
                    else if (item is Armor armor)
                    {

                        Console.WriteLine($"{choiceindex}. {item.name} || 방어력 {armor.defense}");
                        
                    }
                    choiceindex++;
                }
                Console.WriteLine($"{choiceindex}. 뒤로 가기");
                //항상 마지막에 ++ 되서 남은숫자는 뒤로가기로 할당된다
         
                    
                // 상점에서 산 아이템이 목록에 추가되서 3번째 아이템 선택지 만들기
                // 선택지을 리스트에 들어가있는 개체수(칸수)만큼 늘리는법 을 찾기
                Console.Write("장착할 아이템에 번호를 입력해주세요 : ");
               while (true)
               {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int itemIndex) && itemIndex > 0 && itemIndex <= inventory.Count)
                    //숫자 선택시 안넘어가는 현상발생 장착하고 바로 브레이크걸기
                    //입력한숫자가 배열지정 칸수보다 작을시 작동
                    {
                        Item itemnum = inventory[itemIndex - 1];
                        //배열은 항상 0부터 시작하기때문에 -1 해줘서 배열칸수의 번호랑똑같이맞춘다

                        if (itemnum is Weapon weapon)
                        //선택한 칸의 데이터가 클래스 Weapon 일때 작동한다
                        {

                            if (weapon.isEquipped)
                            {
                                weapon.isEquipped = false;
                                user.userWeapon -= weapon.attack;
                                Console.WriteLine("장착이해제 되었습니다.");
                            Console.Clear();
                            break;

                            }
                            else
                            {
                                weapon.isEquipped = true;
                                user.userWeapon += weapon.attack;
                                Console.WriteLine("장착이되엇습니다.");
                            Console.Clear();
                            break;
                            }
                        }
                        else if (itemnum is Armor armor)
                        {
                            if (armor.isEquipped)
                            {
                                armor.isEquipped = false;
                                user.userArmor -= armor.defense;
                                Console.WriteLine("장착이해제 되었습니다.");
                            Console.Clear();
                            break;
                            }
                            else
                            {
                                armor.isEquipped = true;
                                user.userArmor += armor.defense;
                                Console.WriteLine("장착이되엇습니다.");
                            Console.Clear();
                            break;
                            }
                        }
                        
                    }
                    else if (itemIndex == choiceindex)
                    //입력한 숫자가 choiceindex에서
                    //할당된 남은 숫자랑 똑같을때 작동해서 do 루프을 빠져나오기위한 bool를 할당한다 
                    {
                    Console.Clear();
                    break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다");

                    }

               }

        }

        static void Store()
        {

            //보유골드
            Console.WriteLine($"보유골드 : [{user.gold}]");
            Console.WriteLine();
            //아이템 목록
            Console.WriteLine("[아이템 목록]");
            foreach (Item item in store)
            {
                Console.WriteLine();
                if (item is Weapon weapon)
                {
                    if (axe.buy != true)
                    {
                        Console.WriteLine($"{item.name} || 공격력 {weapon.attack} || 가격 {weapon.price}");
                    }
                    else
                    {
                        Console.WriteLine($" {item.name} || 공격력 {weapon.attack} || 구매완료");
                    }
                    
                }
                else if (item is Armor armor)
                {
                    if (huntershirt.buy != true)
                    {
                        Console.WriteLine($"{item.name} || 방어력 {armor.defense} || 가격 {armor.price}");
                    }
                    else
                    {
                        Console.WriteLine($"{item.name} || 방어력 {armor.defense} || 구매 완료");
                    }
                }
            }
            

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 나가기");
            //1.아이템 구메
            //2. 나가기
            Console.Write("원하시는 행동을 입력해주세요. : ");
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Storebuy();
                    break;
                }
                else if (input == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("다시 입력해주세요.");
                }
            }

            
        }
        static void Storebuy()
            //구매 목록
        {
            Console.Clear();
            foreach(Item item in store)
            {
                Console.WriteLine();
                if (item is Weapon weapon)
                {
                    if (axe.buy != true)
                    {
                        Console.WriteLine($"1. {item.name} || 공격력 {weapon.attack} || 가격 {weapon.price}");
                    }    
                    else
                    {
                        Console.WriteLine($"1. {item.name} || 공격력 {weapon.attack} || 구매완료");
                    }
                }
                else if (item is Armor armor)
                {
                    if(huntershirt.buy != true)
                    {
                        Console.WriteLine($"2. {item.name} || 방어력 {armor.defense} || 가격 {armor.price}");
                    }
                    else
                    {
                        Console.WriteLine($"2. {item.name} || 방어력 {armor.defense} || 구매 완료");
                    }
                    
                }
            }
            Console.WriteLine("3. 뒤로가기");
            Console.Write("원하시는 행동을 입력해주세요. : ");
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "1")
                {
                    if (axe.buy == true)
                    {
                        Console.WriteLine("구매하신 항목입니다");
                        Console.WriteLine("다시 입력해주세요.");
                    }
                    else
                    {
                        if (user.gold < axe.price)
                        {
                            Console.WriteLine("보유 골드가 부족 합니다");
                            Console.WriteLine("다시 입력해주세요.");
                        }
                        else
                        {
                            user.gold -= axe.price;
                            axe.buy = true;
                            inventory.Add(axe);
                            Console.WriteLine($"{axe.name}을 구매했습니다. 남은 골드 :{user.gold}");
                            break;
                        }
                    }
                    
                }
                else if (input == "2")
                {
                    if (huntershirt.buy == true)
                    {
                        Console.WriteLine("구매하신 항목입니다");
                        Console.WriteLine("다시 입력해주세요.");
                    }
                    else
                    {
                        if (user.gold < huntershirt.price)
                        {
                            Console.WriteLine("보유 골드가 부족 합니다");
                            Console.WriteLine("다시 입력해주세요.");
                        }
                        else
                        {
                            user.gold -= huntershirt.price;
                            huntershirt.buy = true;
                            inventory.Add(huntershirt);
                            Console.WriteLine($"{huntershirt.name}을 구매했습니다. 남은 골드 :{user.gold}");
                            break;
                        }
                      
                    }
                    break;
                }
                else if(input == "3")
                {
                    break;

                }
                else
                {
                    Console.WriteLine("다시 입력해주세요.");
                }
            }
        }
   }
}
