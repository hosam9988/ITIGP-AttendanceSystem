using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Attendance
    {
        public int StudentId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? AttendAt { get; set; }
        public TimeSpan? LeaveAt { get; set; }

        public virtual Emplyee CreatedByNavigation { get; set; }
        public virtual Student Student { get; set; }
    }
}
