﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CreateLaptopDTO
    {
        public Guid ProcessorId { get; set; }

        public Guid GraphicsCardId { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
