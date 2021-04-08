using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Program
    {
        public Program()
        {
            Tracks = new HashSet<Track>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
