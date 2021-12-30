using FreakyFashionServices.OrderService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.OrderService.Data
{
    public class OrderServiceContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        
        public OrderServiceContext(DbContextOptions<OrderServiceContext> options)
            : base(options)
        {
           
        }
    }

}
