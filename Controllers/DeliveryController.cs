using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodStore.Data;
using WoodStore.Models;
using WoodStore.Models.Entity;

namespace WoodStore.Controllers
{
    public class DeliveryController : Controller
    {
        readonly AppDbContext db;
        public DeliveryController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("GetDeliverys");
            ViewBag.DeliveryId = id;
            return View();
        }
        [HttpPost]
        public string Create(Delivery delivery)
        {
            db.Delivery.Add(delivery);
            db.SaveChanges();
            return "Добро пожаловать в компанию! :)";
        }
        public IActionResult GetDeliverys()
        {
            return View(db.Delivery.ToList().Skip(2));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id != null)
            {
                Delivery delivery = await db.Delivery.FirstOrDefaultAsync(p => p.Id == id);
                if (delivery != null)
                    return View(delivery);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Delivery delivery)
        {
            db.Delivery.Update(delivery);
            await db.SaveChangesAsync();
            return RedirectToAction("GetDeliverys");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Delivery delivery = await db.Delivery.FirstOrDefaultAsync(p => p.Id == id);
                if (delivery != null)
                    return View(delivery);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Delivery delivery = await db.Delivery.FirstOrDefaultAsync(p => p.Id == id);
                if (delivery != null)
                {
                    db.Delivery.Remove(delivery);
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetDeliverys");
                }
            }
            return NotFound();
        }
    }
}