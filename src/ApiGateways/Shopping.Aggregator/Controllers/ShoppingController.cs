using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;

        public ShoppingController(ICatalogService catalogService, IOrderService orderService, IBasketService basketService)
        {
            _catalogService = catalogService;
            _orderService = orderService;
            _basketService = basketService;
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            // get basket with username
            BasketModel basket = await _basketService.GetBasket(userName);

            // iterate basket items and consume products with basket item productId member
            foreach (BasketItemExtendedModel item in basket.Items)
            {
                CatalogModel product = await _catalogService.GetCatalog(item.ProductId);

                // map product related members into basketItem dto with extended columns
                // set additional product fields onto basket item
                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            // consume ordering microservices in order to retrieve order list
            IEnumerable<OrderResponseModel> orders = await _orderService.GetOrdersByUserName(userName);

            // return root ShoppingModel dto class which including all responses
            ShoppingModel shoppingModel = new()
            {
                UserName = userName,
                BasketWithProducts = basket,
                Orders = orders
            };

            return Ok(shoppingModel);
        }
    }
}