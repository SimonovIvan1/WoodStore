using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodStore.Models.Entity
{
    public class Courier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string CarNumber { get; set; }
        public List<Order> Order { get; set; }
    }
}
