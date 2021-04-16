using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PermissionEmployeeManipulationDto
    {
        public bool? ResponseType { get; set; }
        public int? ResponseBy { get; set; }
        public DateTime? ResponseDate { get; set; }

    }
}
