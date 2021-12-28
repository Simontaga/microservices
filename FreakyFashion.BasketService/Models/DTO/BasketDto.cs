using System.Collections.Generic;

namespace FreakyFashion.BasketService.Models.DTO
{
    public class BasketDto
    {
        public string Identifier { get; set; }

        public List<Item> Items { get; set; }
    }


    public class Item
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}


