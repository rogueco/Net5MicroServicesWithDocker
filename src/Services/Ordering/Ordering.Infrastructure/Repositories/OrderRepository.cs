// -----------------------------------------------------------------------
// <copyright company="N/A." file="OrderRepository.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderDbContext) : base(orderDbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            // var orderList = await _dbContext.Orders
            //     .Where(o => o.UserName == userName)
            //     .ToListAsync();

            return await GetAsync(x => x.UserName == userName);
        }
    }
}