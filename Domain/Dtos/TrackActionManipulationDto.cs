using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class TrackActionManipulationDto
    {
        [Required(ErrorMessage ="Track strat date is required")]
        public DateTime Start { get; set; }
        [Required(ErrorMessage = "Track End date is required")]
        public DateTime End { get; set; }
        public string Type { get; set; }
    }
}
