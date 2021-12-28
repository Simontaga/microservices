using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.CatalogService.Models.Domain
{
    public class Product
    {
        public Product(string name, string description, string imageUrl, int price, string articleNumber, string urlSlug)
        {
            ArticleNumber = articleNumber;
            UrlSlug = urlSlug;
            Description = description;
            Name = name;
            Price = price;
            ImageUrl = imageUrl;


        }

        [Key]
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        
        public string UrlSlug { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
        
    }
}
