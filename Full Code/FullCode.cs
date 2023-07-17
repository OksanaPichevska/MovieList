using System;
using System.Collections.Generic;

class Program
{
    static List<string> availableMovies = new List<string>()
    {
        "Хоббіт: Пустка Смауга (фентезі, пригодницький)",
        "Володар перснів: Братство кільця (фентезі, пригодницький)",
        "Темний рицар (екшн, драма, кримінальний)",
        "Залізна Людина (екшн, фантастика, пригодницький)",
        "Месники: Фінал (екшн, фантастика)",
        "Чорна Вдова (екшн, пригодницький)",
        "Зоряні війни Епізод 5: Імперія наносить зворотній удар (фантастика, фентезі, пригодницький, бойовик)",
        "Матриця (фантастика, екшн)",
        "Закляття (жахи, трилер)",
        "Піран'ї (жахи, комедія)",
        "Інтерстеллар (фантастика, драма)",
        "Сяйво (жахи, драма)",
        "Форсаж 10 (екшн, пригодницький)",
        "Дракула (жахи, фентезі)",
        "Барбі (анімація, сімейний)",
        "Драйв (екшн, кримінальний, драма)",
        "Той, хто біжить по лезу 2049 (фантастика, трилер, драма)"
    };

    // Словник для збереження заброньованих квитків
    static Dictionary<string, Dictionary<string, List<Tuple<string, string, int>>>> bookedTickets = new Dictionary<string, Dictionary<string, List<Tuple<string, string, int>>>>();

    static decimal ticketPrice = 125.00m;

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

    // Функція для купівлі квитка
    static void BuyTicket()
    {
        Console.WriteLine("Доступні фільми:");
        for (int i = 0; i < availableMovies.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableMovies[i]}");
        }

        Console.Write("Виберіть номер фільму: ");
        int movieIndex = Convert.ToInt32(Console.ReadLine()) - 1;

        if (movieIndex < 0 || movieIndex >= availableMovies.Count)
        {
            Console.WriteLine("Неправильний вибір фільму.");
            return;
        }

        string selectedMovie = availableMovies[movieIndex];

        // Перевірка, чи існує вже запис для обраного фільму в словнику bookedTickets
        if (!bookedTickets.ContainsKey(selectedMovie))
        {
            // Якщо запису немає, створюємо новий запис
            bookedTickets[selectedMovie] = new Dictionary<string, List<Tuple<string, string, int>>>();
        }

        Console.WriteLine($"Ви обрали фільм: {selectedMovie}");

        Console.WriteLine("Доступні часи показу:");
        Console.WriteLine("1. 12:00");
        Console.WriteLine("2. 15:00");
        Console.WriteLine("3. 18:00");
        Console.WriteLine("4. 21:00");
        Console.Write("Виберіть номер часу показу: ");
        int timeIndex = Convert.ToInt32(Console.ReadLine());

        string selectedTime = GetSelectedTime(timeIndex);
        if (selectedTime == null)
        {
            Console.WriteLine("Неправильний вибір часу.");
            return;
        }
        Console.WriteLine($"Ви обрали час показу: {selectedTime}");

        string selectedDate = GetValidDate();
        if (selectedDate == null)
        {
            Console.WriteLine("Виберіть коректну дату показу.");
            return;
        }
        Console.WriteLine($"Ви обрали дату показу: {selectedDate}");

        Console.Write("Введіть номер місця в залі: ");
        int seatNumber = Convert.ToInt32(Console.ReadLine());

        // Перевірка, чи місце в залі вже заброньоване
        if (IsSeatBooked(selectedMovie, selectedDate, selectedTime, seatNumber))
        {
            Console.WriteLine("Цей квиток вже придбано.");
            return;
        }

        Console.WriteLine($"Ви обрали місце: {seatNumber}");

        Console.Write("Ви бажаєте купити ще один квиток? (Так/Ні): ");
        string continueChoice = Console.ReadLine();

        if (continueChoice.Equals("Так", StringComparison.OrdinalIgnoreCase))
        {
            BuyTicket();
        }

        // Розрахунок загальної суми за квитки
        decimal totalPrice = CalculateTotalPrice(selectedMovie, selectedDate, selectedTime, seatNumber);
        Console.WriteLine($"Загальна сума за квитки: {totalPrice} грн");

        // Додавання квитка до списку заброньованих
        if (!bookedTickets[selectedMovie].ContainsKey(selectedDate))
        {
            bookedTickets[selectedMovie][selectedDate] = new List<Tuple<string, string, int>>();
        }

        bookedTickets[selectedMovie][selectedDate].Add(new Tuple<string, string, int>(selectedTime, selectedDate, seatNumber));
        Console.WriteLine("Квиток придбано!");
    }

    // Функція для відображення заброньованих квитків у особистому кабінеті
    static void ShowPersonalTickets()
    {
        if (bookedTickets.Count == 0)
        {
            Console.WriteLine("У вас немає заброньованих квитків.");
        }
        else
        {
            Console.WriteLine("Заброньовані квитки:");
            int ticketNumber = 1;
            Dictionary<int, Tuple<string, string, int>> ticketDictionary = new Dictionary<int, Tuple<string, string, int>>();

            foreach (var movieTickets in bookedTickets)
            {
                string movie = movieTickets.Key;
                foreach (var dateTimes in movieTickets.Value)
                {
                    string date = dateTimes.Key;
                    foreach (var ticketInfo in dateTimes.Value)
                    {
                        string time = ticketInfo.Item1;
                        int seatNumber = ticketInfo.Item3;
                        Console.WriteLine($"{ticketNumber}. Фільм: {movie}, Дата: {date}, Час: {time}, Місце: {seatNumber}");
                        ticketDictionary[ticketNumber] = Tuple.Create(movie, date, seatNumber);
                        ticketNumber++;
                    }
                }
            }

            if (ticketNumber == 1)
            {
                Console.WriteLine("У вас немає заброньованих квитків.");
            }
        }
    }

    // Функція для відміни квитка
    static void CancelTicket()
    {
        if (bookedTickets.Count == 0)
        {
            Console.WriteLine("У вас немає заброньованих квитків.");
            return;
        }

        Console.WriteLine("Заброньовані квитки:");
        int ticketNumber = 1;
        Dictionary<int, Tuple<string, string, int>> ticketDictionary = new Dictionary<int, Tuple<string, string, int>>();

        foreach (var movieTickets in bookedTickets)
        {
            string movie = movieTickets.Key;
            foreach (var dateTimes in movieTickets.Value)
            {
                string date = dateTimes.Key;
                foreach (var ticketInfo in dateTimes.Value)
                {
                    string time = ticketInfo.Item1;
                    int seatNumber = ticketInfo.Item3;
                    Console.WriteLine($"{ticketNumber}. Фільм: {movie}, Дата: {date}, Час: {time}, Місце: {seatNumber}");
                    ticketDictionary[ticketNumber] = Tuple.Create(movie, date, seatNumber);
                    ticketNumber++;
                }
            }
        }

        if (ticketNumber == 1)
        {
            Console.WriteLine("У вас немає заброньованих квитків.");
            return;
        }

        Console.Write("Введіть номер квитка, який ви хочете відмінити: ");
        int ticketIndex = Convert.ToInt32(Console.ReadLine());

        if (ticketDictionary.ContainsKey(ticketIndex))
        {
            Tuple<string, string, int> ticketInfo = ticketDictionary[ticketIndex];
            string movie = ticketInfo.Item1;
            string date = ticketInfo.Item2;
            int seatNumber = ticketInfo.Item3;

            bookedTickets[movie][date].Remove(new Tuple<string, string, int>(null, null, seatNumber));
            Console.WriteLine("Квиток скасовано!");

            // Видалення квитка з особистого кабінету
            ticketDictionary.Remove(ticketIndex);
        }
        else
        {
            Console.WriteLine("Неправильний номер квитка.");
        }
    }

    // Функція для отримання обраного часу показу
    static string GetSelectedTime(int timeIndex)
    {
        switch (timeIndex)
        {
            case 1:
                return "12:00";
            case 2:
                return "15:00";
            case 3:
                return "18:00";
            case 4:
                return "21:00";
            default:
                return null;
        }
    }

    // Функція для перевірки, чи місце в залі вже заброньоване
    static bool IsSeatBooked(string movie, string date, string time, int seatNumber)
    {
        // Перевірка, чи існує запис для обраного фільму та дати в словнику bookedTickets
        if (bookedTickets.ContainsKey(movie) && bookedTickets[movie].ContainsKey(date))
        {
            // Отримання списку заброньованих місць для обраного фільму, дати та часу
            List<Tuple<string, string, int>> tickets = bookedTickets[movie][date];

            // Перевірка, чи обране місце вже заброньоване
            foreach (var ticket in tickets)
            {
                if (ticket.Item1 == time && ticket.Item3 == seatNumber)
                {
                    return true;
                }
            }
        }

        return false;
    }

    // Функція для розрахунку загальної суми за квитки
    static decimal CalculateTotalPrice(string movie, string date, string time, int seatNumber)
    {
        int ticketCount = 0;

        // Перевірка, чи існує запис для обраного фільму та дати в словнику bookedTickets
        if (bookedTickets.ContainsKey(movie) && bookedTickets[movie].ContainsKey(date))
        {
            // Отримання списку заброньованих місць для обраного фільму, дати та часу
            List<Tuple<string, string, int>> tickets = bookedTickets[movie][date];

            // Перевірка, чи обране місце є новим і ще не заброньованим
            if (!IsSeatBooked(movie, date, time, seatNumber))
            {
                // Кількість квитків дорівнює кількості заброньованих місць, плюс один новий квиток
                ticketCount = tickets.Count + 1;
            }
        }
        else
        {
            // Якщо запису для обраного фільму та дати немає, то кількість квитків - один новий квиток
            ticketCount = 1;
        }

        // Розрахунок загальної суми за квитки
        return ticketCount * ticketPrice;
    }

    // Функція для отримання коректної дати показу
    static string GetValidDate()
    {
        string selectedDate = null;
        bool isDateValid = false;

        while (!isDateValid)
        {
            Console.Write("Виберіть дату показу (ДД.ММ.РРРР): ");
            string inputDate = Console.ReadLine();

            string[] dateParts = inputDate.Split('.');
            if (dateParts.Length != 3)
            {
                Console.WriteLine("Неправильний формат дати.");
                continue;
            }

            int day, month, year;
            if (!int.TryParse(dateParts[0], out day) || !int.TryParse(dateParts[1], out month) || !int.TryParse(dateParts[2], out year))
            {
                Console.WriteLine("Неправильний формат дати.");
                continue;
            }

            if (day < 1 || day > 31 || month < 1 || month > 12 || year < DateTime.Now.Year)
            {
                Console.WriteLine("Виберіть коректну дату.");
                continue;
            }

            DateTime selectedDateTime = new DateTime(year, month, day);
            if (selectedDateTime < DateTime.Now)
            {
                Console.WriteLine("Введіть коректну дату показу.");
                continue;
            }

            selectedDate = inputDate;
            isDateValid = true;
        }

        return selectedDate;
    }
}

