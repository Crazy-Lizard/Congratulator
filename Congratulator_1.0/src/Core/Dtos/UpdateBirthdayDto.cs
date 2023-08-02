using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulator_1._0.src.Core.Dtos
{
    internal class UpdateBirthdayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly Date { get; set; }
    }
}
