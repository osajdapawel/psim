using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Processor : BaseEntity
    {
        [Required]
        [Display(Name = "Procesor")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Wątki")]
        public int NumberOfThreds { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
