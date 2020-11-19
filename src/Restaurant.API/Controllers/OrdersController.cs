using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Restaurant.Application.Services;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderAppServiceFactory _orderAppServiceFactory;

        public OrdersController(IOrderAppServiceFactory orderAppServiceFactory)
        {
            _orderAppServiceFactory = orderAppServiceFactory;
        }

        [HttpGet("{input}")]
        public async Task<IActionResult> InsertOrder([FromRoute] string input)
        {
            try
            {
                var orderAppService = _orderAppServiceFactory.ResolveServiceFrom(input.Trim());
                var result = await orderAppService.ResolveOrdersFromAsync(input.Trim()).ConfigureAwait(true);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
