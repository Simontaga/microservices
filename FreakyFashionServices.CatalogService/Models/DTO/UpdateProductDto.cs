namespace FreakyFashionServices.CatalogService.Models.DTO
{
    public class UpdateProductDto
    {
        public string ArticleNumber { get; set; }

        public string? UrlSlug { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}