using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Coupon_Microservice.Data;
using Coupon_Microservice.Models.CouponDTO;
using Coupon_Microservice.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Coupon_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponController : ControllerBase
    {
    private readonly AppDbContext _db;
    private readonly ResponseDTO _response;
    private readonly IMapper _mapper;


    public CouponController(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _response = new ResponseDTO();
    }

    [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> ObjectList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(ObjectList);
                
 
            }
            catch (System.Exception ex)
            {
                 _response.IsSuccess = false;
                 _response.Message = ex.Message;    
            
            }
            return _response;
        }
    [HttpPost]
    [Route("{ID:int}")]
        public ResponseDTO Get( int ID)
        {
            try
            {
                Coupon ObjectList = _db.Coupons.First(u => u.CouponID == ID);
                _response.Result = _mapper.Map<CouponDTO>(ObjectList);
                 
                
 
            }
            catch (System.Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            
            }
            return _response;
        }
        [HttpGet]
        [Route("GetByCode/{Code}")]
        public ResponseDTO GetByCode(string code)
        {
            try
            {
                Coupon ObjectList = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDTO>(ObjectList);
                if(ObjectList == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Coupon not found";
                }
            }
            catch (System.Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            
            }
            return _response;
        } 
        [HttpPost]
        public ResponseDTO Post([FromBody] CouponDTO couponDto)
        { 
            try
            {
                Coupon Object = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(Object);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDTO>(Object);
                  
            }
            catch (System.Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            
            }
            return _response;

        }
        [HttpPut]
        public ResponseDTO put([FromBody] CouponDTO couponDto)
        { 
            try
            {
                Coupon Object = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(Object);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDTO>(Object);
                  
            }
            catch (System.Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            
            }
            return _response;

        }
        [HttpDelete]
        public ResponseDTO Delete(int ID)
        { 
            try
            {
                Coupon Object = _db.Coupons.FirstOrDefault(u => u.CouponID == ID);
                _db.Coupons.Remove(Object);
                _db.SaveChanges();  
            }
            catch (System.Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            
            }
            return _response;

        }
        
        
    }
}
