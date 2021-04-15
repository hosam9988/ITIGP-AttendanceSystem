using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
   public class PermissionManipulationDto
    {
        public string Noe { get; set; }
        public DateTime Date { get; set; }
        public bool Type { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
