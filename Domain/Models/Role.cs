using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Role
    {
        

        public int Id { get; set; }
        public string RoleName{ get; set; }

        public virtual ICollection<AppUser> Users { get; set; }
    }
}
