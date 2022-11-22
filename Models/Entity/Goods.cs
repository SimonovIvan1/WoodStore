using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.Models.Entity;

namespace WoodStore.Models
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public List<GoodsInOrder> GoodsInOrder { get; set; }

    }
}
