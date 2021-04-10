using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string Noe { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public bool Type { get; set; }
        public bool? ResponseType { get; set; }
        public int? ResponseBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ResponseDate { get; set; }

        public virtual Emplyee ResponseByNavigation { get; set; }
        public virtual Student Student { get; set; }
    }
}
