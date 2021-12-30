using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreakyFashionServices.OrderService.Models.Domain;

namespace FreakyFashionServices.OrderService.Models.Domain
{
    public class Order
    {

        public Order(string customer) 
        {
            Customer = customer;
            
        }


        //public int Id { get; protected set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
        
        public string Customer { get; set; }

        public ICollection<Orderline> Items { get; set; } = new List<Orderline>();
    }
}


