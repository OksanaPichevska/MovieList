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
