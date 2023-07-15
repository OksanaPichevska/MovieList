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
