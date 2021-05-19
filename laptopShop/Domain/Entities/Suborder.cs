using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Suborder : BaseEntity
    {
        public int? OrderId { get; set; }

        [Required]
        public Guid LaptopId { get; set; }

        [Required]
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        [ForeignKey("SuborderOrder")]
        public virtual Order Order { get; set; }

        [ForeignKey("LaptopId")]
        public virtual Laptop Laptop { get; set; }
    }
}
