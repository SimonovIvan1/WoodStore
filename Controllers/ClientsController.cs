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
    public class ClientsController : Controller
    {
        readonly AppDbContext db;
        public ClientsController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.OrderId = id;
            return View();
        }
        [HttpPost]
        public string Create(Clients client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
            return "Спасибо за покупку!";
        }
        public IActionResult GetClients()
        {
            return View(db.Clients.ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Clients client = await db.Clients.FirstOrDefaultAsync(p => p.Id == id);
                if (client != null)
                    return View(client);
            }
            return NotFound();
        }
    }
}
