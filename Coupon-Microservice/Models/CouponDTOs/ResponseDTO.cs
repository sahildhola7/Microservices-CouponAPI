using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon_Microservice.Models.CouponDTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "error";
    }
}