using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.Models.Entity;

namespace WoodStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public int PickerId { get; set; }
        public Picker Picker { get; set; }
        public int SalesManagerId { get; set; }
        public SalesManager SalesManager { get; set; }
        public int ClientsId { get; set; }
        public Clients Clients { get; set; }
        public List<GoodsInOrder> GoodsInOrder { get; set; }

    }
}
