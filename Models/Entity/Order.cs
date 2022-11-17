using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int СourierId { get; set; }
        public int PickerId { get; set; }
        public int SalesManagerId { get; set; }

        public int ClientId { get; set; }
        public Clients Client { get; set; }
    }
}
