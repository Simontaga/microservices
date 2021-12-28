using FreakyFashionServices.CatalogService.Data;
using FreakyFashionServices.CatalogService.Models.Domain;
using FreakyFashionServices.CatalogService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FreakyFashionServices.StockService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        public CatalogController(CatalogServiceContext context)
        {
            Context = context;
        }

        private CatalogServiceContext Context { get; }

        [HttpPost]
        public IActionResult AddProduct(UpdateProductDto updateProductDto)
        {
            char dash = '-';

            string urlSlug = updateProductDto.Name;
            urlSlug = urlSlug.Trim(dash);

            urlSlug = urlSlug.Replace(" ", "-");
            


            var product = new Product(
                   updateProductDto.Name,
                   updateProductDto.Description,
                   updateProductDto.ImageUrl,
                   updateProductDto.Price,
                   updateProductDto.ArticleNumber,
                   urlSlug
                   
               );


            Context.Add(product);

            


            Context.SaveChanges();
            //Serialize product & return

            var created = JsonSerializer.Serialize(product);

            return Created("",product);
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var products = Context.Products.ToList();


            return products;
        }


    }

   

}
