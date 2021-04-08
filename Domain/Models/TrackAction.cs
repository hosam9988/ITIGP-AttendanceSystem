using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class TrackAction
    {
        public TrackAction()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TrackId { get; set; }
        public string Type { get; set; }

        public virtual Track Track { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
