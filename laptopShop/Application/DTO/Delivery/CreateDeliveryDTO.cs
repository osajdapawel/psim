using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CreateDeliveryDTO : IMap
    {
        public string Type { get; set; }

        public int DeliveryTime { get; set; }

        public decimal Price { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDeliveryDTO, Delivery>();
        }
    }
}
