using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Ssn { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public int? Telephone { get; set; }
        public string Address { get; set; }
        public int? TrackActionId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TrackAction TrackAction { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
