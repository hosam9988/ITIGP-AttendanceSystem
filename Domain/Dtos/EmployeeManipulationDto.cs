﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class EmployeeManipulationDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
