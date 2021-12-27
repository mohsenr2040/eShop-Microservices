using AutoMapper;
using ProductApi.Domain.Entities;
using ProductApi.Messaging.Send.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Service.Infrastructure.Automapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdatedProductPriceModel, Product>();
        }
    }
}
