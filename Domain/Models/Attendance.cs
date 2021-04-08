using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? Start { get; set; }
        public TimeSpan? End { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Student IdNavigation { get; set; }
    }
}
