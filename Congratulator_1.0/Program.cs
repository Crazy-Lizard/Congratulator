using Congratulator_1._0.src.Core.Abstractions;
using Congratulator_1._0.src.Core.Dtos;
using Congratulator_1._0.src.Core.Services;
using Congratulator_1._0.src.Infrastructure.Database;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Congratulator
{
    class Program
    {
        static void Main(string[] args) 
        {
            IRepository repository = new InMemoryBirthdayRepository();
            IBirthdayService birthdayService = new BirthdayService(repository);
            while (true)
            {
                Console.WriteLine("1.-Вывести все дни рождения\n" +
                    "2.-Вывести предстоящие дни рождения\n" +
                    "3.-Редактировать день рождения\n" +
                    "4.-Внести день рождения\n" +
                    "5.-Удалить день рождения\n" +
                    "6.-Сохранить записи в файл\n" +
                    "7.-Загрузить записи из файла\n" +
                    //"0.-Выход\n" +
                    "Введите пункт меню:");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Console.WriteLine(string.Join("\n", birthdayService.ShowBirthdays()));
                        break;
                    case 2:
                        Console.WriteLine(string.Join("\n", birthdayService.ShowUpcomingBirthdays()));
                        break;
                    case 3:
                        Console.Write("Введите уникальный номер: ");
                        birthdayService.UpdateBirthday(Update(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case 4:
                        birthdayService.AddBirthday(Add());
                        Console.WriteLine("Элемент успешно добавлен!");
                        break;
                    case 5:
                        Console.Write("Введите уникальный номер: ");
                        birthdayService.RemoveBirthday(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Элемент успешно удалён!");
                        break;
                    case 6:
                        SaveInFile(birthdayService.ShowBirthdays());
                        break;
                    case 7:
                        LoadFromFile(birthdayService);
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода...");
                        break;
                }
                Console.WriteLine();
            }
        }
        static AddBirthdayDto Add()
        {
            Console.Clear();
            Console.Write("Введите имя: "); 
            string name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите день, месяц и год рождения (через enter): ");
            int day = Convert.ToInt32(Console.ReadLine());
            int month = Convert.ToInt32(Console.ReadLine());
            int year = Convert.ToInt32(Console.ReadLine());
            DateOnly date = new DateOnly(year, month, day);
            return new AddBirthdayDto
            {
                Name = name,
                Surname = surname,
                Date = date
            };
        }
        static UpdateBirthdayDto Update(int id)
        {
            Console.Clear();
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите день, месяц и год рождения (через enter): ");
            int day = Convert.ToInt32(Console.ReadLine());
            int month = Convert.ToInt32(Console.ReadLine());
            int year = Convert.ToInt32(Console.ReadLine());
            DateOnly date = new DateOnly(year, month, day);
            return new UpdateBirthdayDto
            {
                Id = id,
                Name = name,
                Surname = surname,
                Date = date
            };
        }
        static void LoadFromFile(IBirthdayService service)
        {
            Console.Write("Введите название файла для получения: ");
            string path = $"{Console.ReadLine()}.txt";
            string pattern = @"^(\d+)\.\s(\w+)\s(\w+)\s:\s(\d{2}\.\d{2}\.\d{4})$";
            List<Birthday> birthdays = new List<Birthday>();

            using (StreamReader sr = new StreamReader(path)) 
            {
                string? line;
                while ((line = sr.ReadLine()) != null) 
                { 
                    Match match = Regex.Match(line, pattern);
                    if (match.Success) 
                    {
                        var groups = match.Groups;
                        birthdays.Add(new Birthday(int.Parse(groups[1].Value), groups[2].Value, groups[3].Value, DateOnly.ParseExact(groups[4].Value, "dd.MM.yyyy", CultureInfo.InvariantCulture)));
                    }
                }
            }

            service.ImportBirthdays(birthdays);
        }
        static void SaveInFile(List<Birthday> birthdays)
        {
            Console.Write("Введите название файла для сохранения: ");
            string path = $"{Console.ReadLine()}.txt";
            using (StreamWriter sw = new StreamWriter(path, false)) 
            {
                sw.WriteLine(string.Join("\n", birthdays));
            }
        }
    }
}