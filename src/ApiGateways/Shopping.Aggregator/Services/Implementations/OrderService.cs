using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;

namespace Shopping.Aggregator.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrderByUserName(string userName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/v1/Order/{userName}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}