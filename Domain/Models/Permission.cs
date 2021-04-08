using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int? StudendId { get; set; }
        public string Type { get; set; }
        public string ResponseType { get; set; }
        public int? ResponseBy { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Employee ResponseByNavigation { get; set; }
        public virtual Student Studend { get; set; }
    }
}
