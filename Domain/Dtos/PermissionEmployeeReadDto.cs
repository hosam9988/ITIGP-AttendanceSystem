using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PermissionEmployeeReadDto
    {
        public int Id { get; set; }

        public string Note { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }

        public string StudentName { get; set; }
        public string TrackName { get; set; }
    }
}
