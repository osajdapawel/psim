using Application.Mappings;
using AutoMapper;
using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class DeliveryDTO : IMap
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public int DeliveryTime { get; set; }

        public decimal Price { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Delivery, DeliveryDTO>();
        }
    }
}
