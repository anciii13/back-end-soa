﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TourEquipmentDto
    {

        public int Id { get; set; }

        public long TourId { get; set; } 
        public long EquipmentId { get; set; } 

        public bool IsSelected { get; set; }
    }
}
