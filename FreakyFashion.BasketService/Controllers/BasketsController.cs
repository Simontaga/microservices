using FreakyFashion.BasketService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreakyFashion.BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
       
        public BasketsController(IDistributedCache cache) 
        {
            Cache = cache;
        }


        public IDistributedCache Cache { get; }

        [HttpGet("{identifier}")]
        public ActionResult<BasketDto> Get(string identifier)
        {
            var serializedBasket = Cache.GetString(identifier);

            if (serializedBasket == null)
                return NotFound(); 

            var basketDto = JsonSerializer.Deserialize<BasketDto>(serializedBasket);

            return Ok(basketDto);
        }

       
        [HttpPut("{id}")]
        public IActionResult Put(BasketDto basketdto)
        {
            var serializedBasket = JsonSerializer.Serialize(basketdto);

            Cache.SetString(basketdto.Identifier, serializedBasket);

            return Created("", null); 
        }

    }
}
