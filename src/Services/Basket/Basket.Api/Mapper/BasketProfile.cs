// -----------------------------------------------------------------------
// <copyright company="N/A." file="BasketProfile.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

using AutoMapper;
using Basket.Api.Entities;
using EventBus.Messages.Events;

namespace Basket.Api.Mapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}