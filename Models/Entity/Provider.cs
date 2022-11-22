﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoodStore.Models.Entity
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public List<Goods> Goods { get; set; }
    }
}
