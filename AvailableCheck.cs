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
