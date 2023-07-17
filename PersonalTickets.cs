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
