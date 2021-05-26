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
    public class LaptopDTO : IMap
    {
        public Guid Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string ProcessorModel { get; set; }

        public int ProcessorNumberOfThreads { get; set; }

        public string GraphicsCardModel { get; set; }

        public int GraphicsVRamAmount { get; set; }

        //public int RamAmount { get; set; }

        public int Quantity { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Laptop, LaptopDTO>();
/*                    .ForMember(p => p.ProcessorModel, l => l.MapFrom(src => src.Processor.Model))
                    .ForMember(p => p.ProcessorNumberOfThreads, l => l.MapFrom(src => src.Processor.NumberOfThreds))
                    .ForMember(p => p.GraphicsCardModel, l => l.MapFrom(src => src.GraphicsCard.Model))
                    .ForMember(p => p.GraphicsVRamAmount, l => l.MapFrom(src => src.GraphicsCard.VRamAmount));*/
        }
    }
}
