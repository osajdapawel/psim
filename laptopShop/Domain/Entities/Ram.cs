using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ram : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Liczba ramu")]
        public float RamAmount { get; set; }

        public ICollection<LaptopRamRelationship> Laptops { get; set; }

        public Ram():base()
        {
        }

        public Ram(string model, string description, float ramAmount):base()
        {
            Model = model;
            Description = description;
            RamAmount = ramAmount;
        }
    }
}
