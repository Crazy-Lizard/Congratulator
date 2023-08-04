using Congratulator_1._0.src.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulator_1._0.src.Core.Abstractions
{
    internal interface IBirthdayService
    {
        List<Birthday> ShowBirthdays();
        List<Birthday> ShowUpcomingBirthdays();
        void AddBirthday(AddBirthdayDto birthday);
        void RemoveBirthday(int id);
        void UpdateBirthday(UpdateBirthdayDto birthday);
        void ImportBirthdays(List<Birthday> birthdays);
    }
}
