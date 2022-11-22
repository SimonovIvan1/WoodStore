using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodStore.Models.Entity
{
    public class GoodsInOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int GoodCount { get; set; }
        public int GoodId { get; set; }
        public Goods Goods { get; set; }
        public Order Order { get; set; }
    }
}
