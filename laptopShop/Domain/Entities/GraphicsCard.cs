using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Klasa modelu kart graficznych
    /// </summary>
    public class GraphicsCard : BaseEntity
    {
        [Required]
        [Display(Name = "Grafika")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "VRAM")]
        public int VRamAmount { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
