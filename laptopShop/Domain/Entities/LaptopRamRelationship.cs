using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LaptopRamRelationship
    {
        public Guid LaptopId { get; set; }
        // to chyba virtual powinno być
        public Laptop Laptop { get; set; }
        public Guid RamId { get; set; }
        public Ram Ram { get; set; }

    }
}
