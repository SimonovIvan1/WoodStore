using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.Models;

namespace WoodStore.Controllers
{
    public class OrderController : Controller
    {
        readonly AppDbContext db;
        public OrderController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("GetOrders");
            ViewBag.OrderId = id;
            return View();
        }
        [HttpPost]
        public string Create(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return "Спасибо за покупку!";
        }
        public IActionResult GetOrders()
        {
            return View(db.Order.ToList());
        }
    }
}
