using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LaptopDTO
    {
        public Guid Id { get; set; }

        public string Model { get; set; }

        public float Price { get; set; }

        public string ProcessorModel { get; set; }

        public int ProcessorNumberOfThreads { get; set; }

        public string GraphicsCardModel { get; set; }

        public int GraphicsVRamAmount { get; set; }

        public int RamAmount { get; set; }

        public int Quantity { get; set; }
    }
}
