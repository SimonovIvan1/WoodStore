using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodStore.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
    }
}
