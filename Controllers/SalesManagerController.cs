using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodStore.Data;
using WoodStore.Models;
using WoodStore.Models.Entity;

namespace WoodStore.Controllers
{
    public class SalesManagerController : Controller
    {
        readonly AppDbContext db;
        public SalesManagerController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("GetAll");
            ViewBag.SalesManagerId = id;
            return View();
        }
        [HttpPost]
        public string Create(SalesManager salesManager)
        {
            db.SalesManager.Add(salesManager);
            db.SaveChanges();
            return "Добро пожаловать в компанию! :)";
        }
        public IActionResult GetAll()
        {
            return View(db.SalesManager.ToList());
        }
      
        public async Task<IActionResult> Update(int? id)
        {
            if (id != null)
            {
                SalesManager salesManager = await db.SalesManager.FirstOrDefaultAsync(p => p.Id == id);
                if (salesManager != null)
                    return View(salesManager);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(SalesManager salesManager)
        {
            db.SalesManager.Update(salesManager);
            await db.SaveChangesAsync();
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                SalesManager salesManager = await db.SalesManager.FirstOrDefaultAsync(p => p.Id == id);
                if (salesManager != null)
                    return View();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                SalesManager salesManager = await db.SalesManager.FirstOrDefaultAsync(p => p.Id == id);
                if (salesManager != null)
                {
                    db.SalesManager.Remove(salesManager);
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetAll");
                }
            }
            return NotFound();
        }
    }
}