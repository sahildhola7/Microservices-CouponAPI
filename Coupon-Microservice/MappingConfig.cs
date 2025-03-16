using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Coupon_Microservice.Models.CouponDTO;
using Coupon_Microservice.Models.Entities;

namespace Coupon_Microservice
{
    public class MappingConfig
    {
         public static MapperConfiguration RegisterMaps()
         {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });
            return mappingConfig;
         

        }
    }
} 