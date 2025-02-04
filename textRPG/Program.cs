namespace textRPG
{
    internal class Program
    {
        static int level = 1;
        static string playerName;
        static string job = "모험가";
        static int attack = 10;
        static int defense = 8;
        static int hp = 15;
        static int gold = 1500;

        List<int> itemID = 
        static void Main(string[] args)
        {
            Console.Write("당신의 이름을 입력해주세요. : ");
            playerName = Console.ReadLine();

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
                            Playerstat();
                            break;
                        case 2:
                            
                        case 4:
                            end = true;
                            break;
                    }

                }
            } while (end == false);
        }
        static void Inventory()
        {
            int[] invenitemID = 

        }
        static void Playerstat()
        {
            bool menuBack = false;
            do
            {
                Console.Clear();
                Console.WriteLine(level);
                Console.WriteLine(playerName);
                Console.WriteLine(job);
                Console.WriteLine(attack);
                Console.WriteLine(defense);
                Console.WriteLine(hp);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. 메인 메뉴로");
                Console.Write("원하시는 행동을 입력해주세요. : ");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    menuBack = true;
                }

            } while (menuBack == false);
        }


    }
}
