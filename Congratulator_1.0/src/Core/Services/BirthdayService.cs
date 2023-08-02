using Congratulator_1._0.src.Core.Abstractions;
using Congratulator_1._0.src.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulator_1._0.src.Core.Services
{
    internal class BirthdayService : IBirthdayService
    {
        private readonly IRepository _repository;
        public BirthdayService(IRepository repository)
        {
            _repository = repository;
        }
        public void AddBirthday(AddBirthdayDto birthday)
        {
            _repository.AddBirthday(new Birthday
            (
                birthday.Id,
                birthday.Name,
                birthday.Surname,
                birthday.Date
            ));
        }

        public void RemoveBirthday(int id)
        {
            var birthday = _repository.ShowBirthdays().FirstOrDefault(birthday => birthday.Id == id);
            if (birthday != null)
                _repository.RemoveBirthday(birthday);
        }

        public List<Birthday> ShowBirthdays()
        {
            return _repository.ShowBirthdays();
        }

        public List<Birthday> ShowUpcomingBirthdays()
        {
            return _repository.ShowBirthdays().Where(birthday => birthday.Date.Day >= DateTime.Now.Day && DateTime.Now.Month == birthday.Date.Month).ToList();
        }

        public void UpdateBirthday(UpdateBirthdayDto birthday)
        {
            var newBirthday = _repository.ShowBirthdays().FirstOrDefault(bd => bd.Id == birthday.Id);
            if (newBirthday == null)
                return;
            newBirthday.Name = birthday.Name;
            newBirthday.Surname = birthday.Surname;
            newBirthday.Date = birthday.Date;
            _repository.UpdateBirthday(newBirthday);
        }
        
    }
}