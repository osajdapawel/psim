using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IMapper _mapper;

        public LaptopService(ILaptopRepository laptopRepository, IMapper mapper)
        {
            _laptopRepository = laptopRepository;
            _mapper = mapper;
        }

    }
}
