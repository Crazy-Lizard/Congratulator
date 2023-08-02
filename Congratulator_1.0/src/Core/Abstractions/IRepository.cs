using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulator_1._0.src.Core.Abstractions
{
    internal interface IRepository
    {
        List<Birthday> ShowBirthdays();
        void AddBirthday(Birthday birthday);
        void RemoveBirthday(Birthday birthday);
        void UpdateBirthday(Birthday birthday);
    }
}
