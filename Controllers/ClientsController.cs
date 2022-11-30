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
            if (id == null) return RedirectToAction("GetClients");
            ViewBag.ClientsId = id;
            return View();
        }
        [HttpPost]
        public string Create(Clients client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
            return "Добавлен новый клиент!";
        }
        public IActionResult GetClients()
        {
            return View(db.Clients.OrderBy(x => x.Name).ToList()); 
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

        public async Task<IActionResult> Update(int? id)
        {
            if (id != null)
            {
                Clients clients = await db.Clients.FirstOrDefaultAsync(p => p.Id == id);
                if (clients != null)
                    return View(clients);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Clients clients)
        {
            db.Clients.Update(clients);
            await db.SaveChangesAsync();
            return RedirectToAction("GetClients");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Clients clients = await db.Clients.FirstOrDefaultAsync(p => p.Id == id);
                if (clients != null)
                    return View(clients);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Clients clients = await db.Clients.FirstOrDefaultAsync(p => p.Id == id);
                if (clients != null)
                {
                    db.Clients.Remove(clients);
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetClients");
                }
            }
            return NotFound();
        }
    }
}
