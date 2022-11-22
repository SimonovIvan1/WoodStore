using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodStore.Models.Entity
{
    public class SalesManager
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Telephone { get; set; }
        public List<Order> Order { get; set; }
    }
}
