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
    public class UpdateOrderDTO : IMap
    {
        public Guid Id { get; set; }

        public Guid? DeliveryId { get; set; }




        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDTO, Order>();      
        }
    }
}
