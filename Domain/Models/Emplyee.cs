using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Employee //app user
    {
        public Employee()
        {
            Attendances = new HashSet<Attendance>();
            InverseCreatedByNavigation = new HashSet<Employee>();
            Permissions = new HashSet<Permission>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Employee> InverseCreatedByNavigation { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
