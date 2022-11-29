using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WoodStore.Data;
using WoodStore.Models;
using WoodStore.Models.Entity;

namespace WoodStore.Controllers
{
    public class ProviderController : Controller
    {
        readonly AppDbContext db;
        public ProviderController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null) return RedirectToAction("GetProviders");
            ViewBag.ProviderId = id;
            return View();
        }
        [HttpPost]
        public string Create(Provider provider)
        {
            db.Provider.Add(provider);
            db.SaveChanges();
            return "Добавлен новый поставщик!";
        }
        public IActionResult GetProviders()
        {
            return View(db.Provider.ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Provider provider = await db.Provider.FirstOrDefaultAsync(p => p.Id == id);
                if (provider != null)
                    return View(provider);
            }
            return NotFound();
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id != null)
            {
                Provider provider = await db.Provider.FirstOrDefaultAsync(p => p.Id == id);
                if (provider != null)
                    return View(provider);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Provider provider)
        {
            db.Provider.Update(provider);
            await db.SaveChangesAsync();
            return RedirectToAction("GetProviders");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Provider provider = await db.Provider.FirstOrDefaultAsync(p => p.Id == id);
                if (provider != null)
                    return View(provider);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Provider provider = await db.Provider.FirstOrDefaultAsync(p => p.Id == id);
                if (provider != null)
                {
                    db.Provider.Remove(provider);
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetProviders");
                }
            }
            return NotFound();
        }
    }
}