using System;
using System.Collections.Generic;

class Program
{
    static List<string> availableMovies = new List<string>()
    {
        "Хоббіт: Пустка Смауга",
        "Володар перснів: Братство кільця",
        "Темний рицар",
        "Залізна людина",
        "Месники: Фінал",
        "Піран'ї",
        "Чорна Вдова",
        "Зоряні війни Епізод V: Імперія наносить зворотній удар",
        "Матриця",
        "Закляття",
        "Інтерстеллар",
        "Сяйво",
        "Форсаж X"
    };

    // Словник для збереження заброньованих квитків
    static Dictionary<string, Dictionary<string, List<int>>> bookedTickets = new Dictionary<string, Dictionary<string, List<int>>>();

    static decimal ticketPrice = 125.00m;
