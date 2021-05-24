using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        public Guid? DeliveryId { get; set; }

        public string UserId { get; set; }

        public EnumStatus? Status { get; set; }

        // zobaczyć czy tak kolekcja zwróci listę obiektów zamówień
        public virtual ICollection<Suborder> Suborders { get; set; }
    }
}
// cene dodać 
