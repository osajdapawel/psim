using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class OrderDTO : IMap
    {
        public Guid Id { get; set; }

        public Guid? DeliveryId { get; set; }

        public string DeliveryName { get; set; }

        public DateTime Created { get; set; }

        public string UserId { get; set; }

        public EnumStatus? Status { get; set; }

        public decimal TotalPrice { get; set; }

        // zobaczyć czy tak kolekcja zwróci listę obiektów zamówień
        public virtual ICollection<Suborder> Suborders { get; set; }


        public void Mapping(Profile profile)
        {
            // megazord -- może się wykrzaczyć
            // możliwe, ze potrzebny będzie include
            profile.CreateMap<Order, OrderDTO>()                   // całkowity koszt = SUMA( laptop * cena ) + cena dostawy
                .ForMember(p => p.TotalPrice, o => o.MapFrom(src => src.Suborders.Sum(so => so.Quantity * so.Laptop.Price) + src.Delivery.Price))
                .ForMember(p => p.DeliveryName, o => o.MapFrom( src => src.Delivery.Type));
        }
    }
}
// cene dodać 
