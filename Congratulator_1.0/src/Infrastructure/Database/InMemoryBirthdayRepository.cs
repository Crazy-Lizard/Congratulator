using Congratulator_1._0.src.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulator_1._0.src.Infrastructure.Database
{
    internal class InMemoryBirthdayRepository : IRepository
    {
        private readonly List<Birthday> _birthdays = new();
        public InMemoryBirthdayRepository()
        {
            _birthdays.Add(new Birthday(1, "Name1", "Surname1", new DateOnly(2000, 12, 12)));
            _birthdays.Add(new Birthday(2, "Name2", "Surname2", new DateOnly(2012, 12, 12)));
            _birthdays.Add(new Birthday(3, "Name3", "Surname3", new DateOnly(2003, 6, 5)));
            _birthdays.Add(new Birthday(4, "Name4", "Surname4", new DateOnly(2009, 8, 7)));
        }
        public void AddBirthday(Birthday birthday)
        {
            birthday.Id = _birthdays.Max(b => b.Id) + 1;
            _birthdays.Add(birthday);
        }

        public void RemoveBirthday(Birthday birthday)
        {
            _birthdays.Remove(birthday);
        }

        public List<Birthday> ShowBirthdays()
        {
            return _birthdays;
        }

        public void UpdateBirthday(Birthday birthday)
        {
            int index = _birthdays.IndexOf(birthday);
            _birthdays[index] = birthday;
        }
    }
}
