using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Models
{
    public partial class Employee //app user
    {
        public Employee()
        {
            Attendances = new HashSet<Attendance>();
            //InverseCreatedByNavigation = new HashSet<Employee>();
            Permissions = new HashSet<Permission>();
            Students = new HashSet<Student>();
        }



        public int Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }

        //[ForeignKey("Role")]
        //public int RoleId { get; set; }
        //public int? CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(CreatedByNavigation))]
        public int? CreatedBy { get; set; }
        public virtual Employee CreatedByNavigation { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Employee> InverseCreatedByNavigation { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Student> Students { get; set; }
       // public virtual Role Role { get; set; }
        public virtual AppUser User { get; set; }
    }
}