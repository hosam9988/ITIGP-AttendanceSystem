using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TrackId { get; set; }

        public virtual Track Track { get; set; }
    }
}
