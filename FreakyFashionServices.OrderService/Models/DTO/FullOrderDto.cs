using FreakyFashionServices.OrderService.Models.Domain;

namespace FreakyFashionServices.OrderService.Models.DTO
{
    public class FullOrderDto
    {
        public string Identifier { get; set; }

        public List<Orderline> Items { get; set; }
    }
}
