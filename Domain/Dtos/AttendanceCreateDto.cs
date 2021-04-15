using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class AttendanceCreateDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? AttendAt { get; set; }
        public TimeSpan? LeaveAt { get; set; }
    }
}
