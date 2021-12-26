using ProductApi.Domain.Entities;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ProductApi.Infrastructure.Automapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductModel, Product>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<UpdateProductModel, Product>()
                .ForMember(x => x.ViewCount, opt => opt.Ignore());
        }

    }
}
