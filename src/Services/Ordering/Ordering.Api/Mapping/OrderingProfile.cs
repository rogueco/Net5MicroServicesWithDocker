// -----------------------------------------------------------------------
// <copyright company="N/A." file="OrderingProfile.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.Api.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}