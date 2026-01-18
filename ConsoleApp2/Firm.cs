using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp2
{
    class Firm
    {
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public string Profile { get; set; }
        public string Director { get; set; }
        public int Employees { get; set; }
        public string Address { get; set; }

        public void Print()
        {
            Console.WriteLine($"Назва: {Name}");
            Console.WriteLine($"Дата заснування: {Founded.ToShortDateString()}");
            Console.WriteLine($"Профіль: {Profile}");
            Console.WriteLine($"Директор: {Director}");
            Console.WriteLine($"К-сть співробітників: {Employees}");
            Console.WriteLine($"Адреса: {Address}");
            Console.WriteLine(new string('-', 40));
        }
    }

    class Program
    {
        static void Main()
        {
            List<Firm> firms = new List<Firm>
        {
            new Firm
            {
                Name = "White Food Ltd",
                Founded = DateTime.Now.AddYears(-3),
                Profile = "Marketing",
                Director = "John White",
                Employees = 150,
                Address = "London"
            },
            new Firm
            {
                Name = "Black IT Solutions",
                Founded = DateTime.Now.AddDays(-123),
                Profile = "IT",
                Director = "Mark Black",
                Employees = 90,
                Address = "Kyiv"
            },
            new Firm
            {
                Name = "Green Market",
                Founded = DateTime.Now.AddYears(-1),
                Profile = "Marketing",
                Director = "Anna Brown",
                Employees = 280,
                Address = "London"
            }
        };

            PrintResult("Усі фірми", firms);

            PrintResult("Фірми з словом Food у назві",
                firms.Where(f => f.Name.Contains("Food")));

            PrintResult("Фірми у сфері маркетингу",
                firms.Where(f => f.Profile == "Marketing"));

            PrintResult("Фірми у сфері маркетингу або IT",
                firms.Where(f => f.Profile == "Marketing" || f.Profile == "IT"));

            PrintResult("Фірми з кількістю працівників > 100",
                firms.Where(f => f.Employees > 100));

            PrintResult("Фірми з кількістю працівників від 100 до 300",
                firms.Where(f => f.Employees >= 100 && f.Employees <= 300));

            PrintResult("Фірми, що знаходяться в Лондоні",
                firms.Where(f => f.Address == "London"));

            PrintResult("Фірми, де директор White",
                firms.Where(f => f.Director.Contains("White")));

            PrintResult("Фірми, засновані більше 2 років тому",
                firms.Where(f => (DateTime.Now - f.Founded).TotalDays > 730));

            PrintResult("Фірми, засновані 123 дні тому",
                firms.Where(f => (DateTime.Now - f.Founded).Days == 123));

            PrintResult("Директор Black і назва містить White",
                firms.Where(f =>
                    f.Director.Contains("Black") &&
                    f.Name.Contains("White")));
        }

        static void PrintResult(string title, IEnumerable<Firm> firms)
        {
            Console.WriteLine($"\n=== {title} ===");

            if (!firms.Any())
            {
                Console.WriteLine("Нічого не знайдено");
                return;
            }

            foreach (var firm in firms)
            {
                firm.Print();
            }
        }
    }

}