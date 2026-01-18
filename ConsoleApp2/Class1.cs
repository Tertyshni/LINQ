using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp2
{
    class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Phone> phones = new List<Phone>;
            {
                new Phone
                {
                    Name = "Galaxy S21",
                    Manufacturer = "Samsung",
                    Price = 799.99m,
                    ReleaseDate = new DateTime(2021, 1, 29)
                },
                new Phone
                {
                    Name = "iPhone 13",
                    Manufacturer = "Apple",
                    Price = 999.99m,
                    ReleaseDate = new DateTime(2021, 9, 24)
                },
                new Phone
                {
                    Name = "Pixel 6",
                    Manufacturer = "Google",
                    Price = 599.99m,
                    ReleaseDate = new DateTime(2021, 10, 28)
                }
            }
            ;
            Console.WriteLine("Кількість телефонів: " + phones.Count());

            Console.WriteLine("Телефонів з ціною > 100: " +
                phones.Count(p => p.Price > 100));

            Console.WriteLine("Телефонів з ціною від 400 до 700: " +
                phones.Count(p => p.Price >= 400 && p.Price <= 700));

            Console.WriteLine("Телефонів виробника Samsung: " +
                phones.Count(p => p.Manufacturer == "Samsung"));

            var minPrice = phones.OrderBy(p => p.Price).First();
            Console.WriteLine("\nТелефон з мінімальною ціною:");
            Print(minPrice);

            var maxPrice = phones.OrderByDescending(p => p.Price).First();
            Console.WriteLine("\nТелефон з максимальною ціною:");
            Print(maxPrice);

            var oldest = phones.OrderBy(p => p.ReleaseDate).First();
            Console.WriteLine("\nНайстаріший телефон:");
            Print(oldest);

            var newest = phones.OrderByDescending(p => p.ReleaseDate).First();
            Console.WriteLine("\nНайновіший телефон:");
            Print(newest);

            Console.WriteLine("\nСередня ціна телефону: " +
                phones.Average(p => p.Price));
        }

        static void Print(Phone p)
        {
            Console.WriteLine($"{p.Name}, {p.Manufacturer}, ціна: {p.Price}, дата випуску: {p.ReleaseDate.ToShortDateString()}");
        }
    }
}