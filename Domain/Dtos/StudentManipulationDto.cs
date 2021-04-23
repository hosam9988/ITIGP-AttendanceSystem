using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class StudentManipulationDto
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        [StringLength(14, MinimumLength = 14)]
        [RegularExpression(@"[0-9]")]
        public string Ssn { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }   
    }
}
