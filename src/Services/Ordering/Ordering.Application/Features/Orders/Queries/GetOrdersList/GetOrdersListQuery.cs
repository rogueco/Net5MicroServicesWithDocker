// -----------------------------------------------------------------------
// <copyright company="N/A." file="GetOrdersListQuery.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersVm>>
    {
        public GetOrdersListQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
        
    }
}