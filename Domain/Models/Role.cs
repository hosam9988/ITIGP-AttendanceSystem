using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Role
    {
        public Role()
        {
            Emplyees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; }

        public virtual ICollection<Employee> Emplyees { get; set; }
    }
}
