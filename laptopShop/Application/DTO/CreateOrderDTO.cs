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
    public class CreateOrderDTO : IMap
    {
        public Guid? DeliveryId { get; set; }

        public Guid UserId { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDTO, Order>();
        }
    }
}
