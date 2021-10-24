// -----------------------------------------------------------------------
// <copyright company="N/A." file="DiscountProfile.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}