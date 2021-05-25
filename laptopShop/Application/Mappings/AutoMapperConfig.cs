using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;
using Domain.Authentication;

namespace Application.Mappings
{
    /// <summary>
    /// Klasa konfiguracji mappera
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Konfiguracja mapppera
        /// </summary>
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Laptop, LaptopDTO>();
                //cfg.CreateMap<LaptopDTO, Laptop>();
                cfg.CreateMap<CreateLaptopDTO, Laptop>();
                cfg.CreateMap<UpdateLaptopDTO, Laptop>();
                cfg.CreateMap<Laptop, LaptopDTO>()
                    .ForMember(p => p.ProcessorModel, l => l.MapFrom(src => src.Processor.Model))
                    .ForMember(p => p.ProcessorNumberOfThreads, l => l.MapFrom(src => src.Processor.NumberOfThreds))
                    .ForMember(p => p.GraphicsCardModel, l => l.MapFrom(src => src.GraphicsCard.Model))
                    .ForMember(p => p.GraphicsVRamAmount, l => l.MapFrom(src => src.GraphicsCard.VRamAmount));

                //do dokończenia - cene zmapować
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<ApplicationUser,  UserDTO>();

                cfg.CreateMap<Suborder, SuborderDTO>();

            }).CreateMapper();
    }
}
