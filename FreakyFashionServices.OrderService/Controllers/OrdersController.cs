using FreakyFashionServices.OrderService.Data;
using FreakyFashionServices.OrderService.Models.Domain;
using FreakyFashionServices.OrderService.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace FreakyFashionServices.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IHttpClientFactory httpClientFactory;


        public OrdersController(IHttpClientFactory httpClientFactory,OrderServiceContext context)
        {
            this.httpClientFactory = httpClientFactory;
            Context = context;
        }


        private OrderServiceContext Context { get; }


        [HttpPost]

        public async Task<IActionResult> CreateOrder(OrderDto orderDto) 
        {

          

            if (orderDto.Identifier != null)
            {


                var fullOrderDto = await FetchFullOrder(orderDto.Identifier);


                

                Order order = new Order(orderDto.Customer);

                order.Items = fullOrderDto.Items;

                var newOrder = Context.Orders.Add(order);

                Context.SaveChanges();

                var createdOrderDto = new CreatedOrderDto();

                createdOrderDto.orderId = order.orderId;

                string orderId = JsonSerializer.Serialize(createdOrderDto);
                return Created("", orderId);


            }




            return NotFound();
        }

        private async Task<FullOrderDto> FetchFullOrder(string identifier) 
        {
            //Create an order -> get from redis service
            //gör http req till http://localhost:5232/api/Baskets/<IDENTIFIER>
            var httpRequestMessage = new HttpRequestMessage(
           HttpMethod.Get,
           $"http://localhost:5232/api/Baskets/{identifier}")
            {
                Headers = { { HeaderNames.Accept, "application/json" }, }
            };

            var httpClient = httpClientFactory.CreateClient();

            using var httpResponseMessage =
                await httpClient.SendAsync(httpRequestMessage);



            if (!httpResponseMessage.IsSuccessStatusCode)
                return null;

            using var contentStream =
            await httpResponseMessage.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var fullOrderDto = await JsonSerializer.DeserializeAsync
                    <FullOrderDto>(contentStream, options);


            return fullOrderDto;
        }

    }
}
