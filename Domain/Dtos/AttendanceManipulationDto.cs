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
        public string StudentName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Date { get; set; }

        //[System.Text.Json.Serialization.JsonConverterAttribute(typeof(TimeSpanConverter))]
        public string AttendAt { get; set; }
        public string LeaveAt { get; set; }
    }
}
