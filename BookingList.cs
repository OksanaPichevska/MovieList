// Додавання квитка до списку заброньованих
        if (!bookedTickets[selectedMovie].ContainsKey(selectedDate))
        {
            bookedTickets[selectedMovie][selectedDate] = new List<Tuple<string, string, int>>();
        }

        bookedTickets[selectedMovie][selectedDate].Add(new Tuple<string, string, int>(selectedTime, selectedDate, seatNumber));
        Console.WriteLine("Квиток придбано!");
    }
