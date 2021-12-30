using FreakyFashionServices.OrderService.Models.Domain;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Orderline
    {
        public Orderline(int productId, int quantity) 
        {
            ProductId = productId;
            
            Quantity = quantity;
        }

        public int Id { get; protected set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

