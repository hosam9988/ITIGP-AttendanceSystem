using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Converters;

namespace Domain.Dtos
{
    public class AttendanceManipulationDto
    {
        public int CreatedBy { get; set; }
        public DateTime Date { get; set; }

        public string AttendAt { get; set; }
        public string LeaveAt { get; set; }

    }
}
