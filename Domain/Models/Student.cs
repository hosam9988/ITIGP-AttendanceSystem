using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Student //app user
    {
        public Student()
        {
            Attendees = new HashSet<Attendance>();
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Ssn { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int? TrackActionId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual TrackAction TtackAction { get; set; }
        public virtual ICollection<Attendance> Attendees { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
