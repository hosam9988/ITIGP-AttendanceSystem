using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AppUser
    {
        public AppUser()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Student Student { get; set; }
        public virtual Role Role { get; set; }
    }
}

