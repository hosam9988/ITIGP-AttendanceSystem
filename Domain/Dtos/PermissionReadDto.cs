﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PermissionReadDto
    {
        public string Noe { get; set; }
        public DateTime Date { get; set; }
        public bool Type { get; set; }
        public bool? ResponseType { get; set; }
        public int? ResponseBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
}
