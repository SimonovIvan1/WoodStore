﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}