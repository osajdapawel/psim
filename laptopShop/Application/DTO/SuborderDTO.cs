﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    class SuborderDTO
    {
        public Guid? OrderId { get; set; }

        public Guid LaptopId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
