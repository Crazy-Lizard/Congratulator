using Congratulator_1._0.src.Core.Abstractions;
using Congratulator_1._0.src.Core.Dtos;
using Congratulator_1._0.src.Core.Services;
using Congratulator_1._0.src.Infrastructure.Database;
using System;

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
    }
}