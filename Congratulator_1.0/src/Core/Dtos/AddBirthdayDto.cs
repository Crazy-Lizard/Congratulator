using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulator_1._0.src.Core.Dtos
{
    internal class AddBirthdayDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; init; }
        public string Surname { get; init; }
        public DateOnly Date { get; init; }
    }
}
