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
            if (!int.TryParse(dateParts[0], out day)  !int.TryParse(dateParts[1], out month)  !int.TryParse(dateParts[2], out year))
            {
                Console.WriteLine("Неправильний формат дати.");
                continue;
            }

            if (day < 1  day > 31  month < 1  month > 12  year < DateTime.Now.Year)
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
