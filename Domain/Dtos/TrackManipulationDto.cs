using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class TrackManipulationDto
    {
        [Required(ErrorMessage = "Track Name is required")]
        public string Name { get; set; }
        
    }
}
