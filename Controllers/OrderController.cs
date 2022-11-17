using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.Data;
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Order order = await db.Order.FirstOrDefaultAsync(p => p.Id == id);
                if (order != null)
                return View(order);
            }
            return NotFound();
        }
    }
}
