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
    public class SuborderDTO : IMap
    {
        public Guid Id { get; set; }

        public Guid? OrderId { get; set; }

        public Guid LaptopId { get; set; }

        public string LaptopName { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime Created { get; set; }


        //laptop name zmapować
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Suborder, SuborderDTO>();
        }
    }
}
