using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Klasa modelu dostaw
    /// </summary>
    public class Delivery : BaseEntity
    {
        [Required, MaxLength(50)]
        [Display(Name = "Typ")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Czas")]
        public int DeliveryTime { get; set; }

        [Required]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        public Delivery(string type, int deliveryTime, decimal price):base()
        {
            Type = type;
            DeliveryTime = deliveryTime;
            Price = price;
        }
        public Delivery() : base()
        {
        }
    }
}
