using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ProgramManipulationDto
    {
        [Required(ErrorMessage ="Program Name is required")]
        public string Name { get; set; }
    }
}
