// -----------------------------------------------------------------------
// <copyright company="N/A." file="BasketCheckoutConsumer.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using EventBus.Messages.Events;
using MassTransit;

namespace Ordering.Api.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        public Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            throw new System.NotImplementedException();
        }
    }
}