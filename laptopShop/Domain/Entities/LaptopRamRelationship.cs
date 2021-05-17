using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LaptopRamRelationship
    {
        public int LaptopId { get; set; }
        public Laptop Laptop { get; set; }
        public int RamId { get; set; }
        public Ram Ram { get; set; }
    }
}
