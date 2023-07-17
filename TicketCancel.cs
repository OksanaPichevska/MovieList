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
