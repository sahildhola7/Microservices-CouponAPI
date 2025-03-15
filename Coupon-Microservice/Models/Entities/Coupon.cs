using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon_Microservice.Models.Entities
{
    public class Coupon
    {
        public int CouponID { get; set; }
        public required string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public DateTime  LastUpdated { get; set; }
    
    }
}