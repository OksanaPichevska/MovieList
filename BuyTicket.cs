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
