static void Main(string[] args)
    {
        bool isRunning = true;
        Console.WriteLine("Привіт! Наша команда рада, що Ви вирішили обрати кінотеатр ReelRiot :)");
        Console.Write("Як Вас звати? ");
        string userName = Console.ReadLine();
        Console.Write($"Приємно познайомитись, {userName}!");
        Console.WriteLine("Нижче Ви можете побачити меню. Оберіть необхідний Вам варіант:");
        while (isRunning)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Купити квиток");
            Console.WriteLine("2. Особистий кабінет");
            Console.WriteLine("3. Відмінити квиток");
            Console.WriteLine("4. Вихід");
            Console.Write("Виберіть опцію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BuyTicket();
                    break;
                case "2":
                    ShowPersonalTickets();
                    break;
                case "3":
                    CancelTicket();
                    break;
                case "4":
                    isRunning = false;
                    Console.WriteLine($"Дякуємо за Ваш вибір, {userName}! До нових зустрічей у кінотеатрі ReelRiot :)");
                    break;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }

            Console.WriteLine();
        }
    }
