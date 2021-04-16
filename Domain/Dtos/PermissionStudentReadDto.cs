using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PermissionStudentReadDto
    {
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string ResponseType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
}
